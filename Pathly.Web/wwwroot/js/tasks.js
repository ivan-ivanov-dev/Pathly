const TaskManager = {
    init: function () {
        this.bindEvents();
        this.initFooterTips();
        this.initModalFocus();
        KanbanBoard.init();
    },

    bindEvents: function () {
        $(document).on('click', '.delete-task-btn', (e) => this.handleDelete(e));
        $(document).on('click', '.btn-status-pill', (e) => this.handleStatusToggle(e));
        document.addEventListener("click", (e) => this.handleModalClick(e));

        const searchInput = document.getElementById('kanbanSearch');
        const priorityFilter = document.getElementById('priorityFilter');

        if (searchInput) searchInput.addEventListener('input', () => KanbanBoard.filterTasks());
        if (priorityFilter) priorityFilter.addEventListener('change', () => KanbanBoard.filterTasks());

        document.addEventListener("change", (e) => {
            if (e.target.classList.contains('priority-select-direct') || e.target.classList.contains('priority-select-slim')) {
                this.handlePriorityUpdate(e);
            }
            this.handleTagValidation(e);
        });
        document.addEventListener("submit", (e) => this.handleFormSubmit(e), true);
    },

    handleStatusToggle: function (e) {
        const btn = e.currentTarget;
        const cardWrapper = btn.closest('.task-card-wrapper');
        const taskId = cardWrapper.getAttribute('data-id');

        fetch(`/Tasks/MarkTaskStatus/${taskId}`, {
            method: "POST",
            headers: { "X-Requested-With": "XMLHttpRequest" }
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    const targetStatus = data.isCompleted ? "3" : "1";
                    const targetColumn = document.querySelector(`.kanban-column-body[data-status="${targetStatus}"]`);

                    if (targetColumn && cardWrapper) {
                        cardWrapper.style.transition = 'all 0.3s ease';
                        cardWrapper.style.opacity = '0';
                        cardWrapper.style.transform = 'scale(0.8)';

                        setTimeout(() => {
                            targetColumn.appendChild(cardWrapper);

                            const isDone = data.isCompleted;
                            btn.classList.toggle('btn-success', isDone);
                            btn.classList.toggle('btn-outline-secondary', !isDone);
                            btn.querySelector('i').className = isDone ? 'bi bi-check-lg' : 'bi bi-circle';
                            cardWrapper.querySelector('.task-card').classList.toggle('task-completed', isDone);

                            cardWrapper.style.opacity = '1';
                            cardWrapper.style.transform = 'scale(1)';

                            KanbanBoard.filterTasks();
                        }, 300);
                    }
                }
            });
    },
    handleDelete: function (e) {
        e.preventDefault();
        const btn = $(e.currentTarget);
        const taskId = btn.data('id');
        const taskTitle = btn.data('title') || "this task";
        const token = $('input[name="__RequestVerificationToken"]').val();

        Swal.fire({
            title: 'Are you sure?',
            text: `You are about to delete "${taskTitle}". This cannot be undone!`,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#0F4C5C',
            cancelButtonColor: '#6c757d',
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'Cancel',
            customClass: {
                popup: 'rounded-4 shadow-lg',
                confirmButton: 'rounded-pill px-4',
                cancelButton: 'rounded-pill px-4'
            }
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Tasks/DeleteAsync/${taskId}`,
                    type: 'POST',
                    data: { __RequestVerificationToken: token },
                    success: (response) => {
                        if (response.success) {
                            Swal.fire({
                                title: 'Deleted!',
                                text: response.message || 'Task removed.',
                                icon: 'success',
                                confirmButtonColor: '#0F4C5C',
                                timer: 1500
                            }).then(() => {
                                const roadmapItem = document.getElementById(`task-item-${taskId}`) || document.getElementById(`task-wrapper-${taskId}`);
                                if (roadmapItem) {
                                    $(roadmapItem).fadeOut(300, () => roadmapItem.remove());
                                } else {
                                    location.reload();
                                }
                            });
                        }
                    },
                    error: () => Swal.fire('Error!', 'Could not delete task.', 'error')
                });
            }
        });
    },

    initModalFocus: function () {
        const modalEl = document.getElementById('taskModal');
        if (!modalEl) return;
        modalEl.addEventListener('shown.bs.modal', () => {
            const titleInput = document.querySelector('#taskModalBody input[name="Title"], #taskModalBody #Title');
            if (titleInput) titleInput.focus();
        });
    },

    handleModalClick: function (e) {
        const btn = e.target.closest("[data-modal-url]");
        if (!btn) return;

        e.preventDefault();
        e.stopPropagation();

        const url = btn.getAttribute("data-modal-url");
        const title = btn.getAttribute("data-modal-title") || "Task Details";

        fetch(url)
            .then(r => r.text())
            .then(html => {
                const modalBody = document.getElementById("taskModalBody");
                const modalTitle = document.getElementById("taskModalTitle");

                if (modalBody) modalBody.innerHTML = html;
                if (modalTitle) modalTitle.textContent = title;

                const modalEl = document.getElementById("taskModal");
                let modal = bootstrap.Modal.getOrCreateInstance(modalEl);
                modal.show();
                this.rebindValidation();
            })
            .catch(() => alert("Failed to load modal content."));
    },

    handlePriorityUpdate: function (e) {
        const select = e.target;
        const newPriority = select.value; 
        const card = select.closest('.task-card');
        const form = select.closest('form');

        fetch(form.action, {
            method: "POST",
            body: new FormData(form),
            headers: { "X-Requested-With": "XMLHttpRequest" }
        })
            .then(response => {
                if (response.ok) {
                    const themes = { "1": "success", "2": "warning", "3": "orange", "4": "danger" };
                    const newTheme = themes[newPriority] || "success";

                    select.className = `form-select form-select-sm priority-select-direct pathly-dropdown bg-soft-${newTheme}`;

                    card.setAttribute('data-priority-theme', newTheme);
                }
            });
    },

    handleFormSubmit: function (e) {
        const form = e.target.closest(".task-form");
        if (!form) return;

        e.preventDefault();
        const formData = new FormData(form);

        fetch(form.getAttribute("action"), {
            method: "POST",
            body: formData,
            headers: { "X-Requested-With": "XMLHttpRequest" }
        })
            .then(async response => {
                const isHtml = response.headers.get("content-type")?.includes("text/html");

                if (response.ok && !isHtml) {
                    if (window.location.pathname.includes("Roadmap")) {
                        location.reload();
                    } else {
                        window.location.href = '/Tasks/Index';
                    }
                } else if (isHtml) {
                    const html = await response.text();
                    document.getElementById("taskModalBody").innerHTML = html;
                    this.rebindValidation();
                }
            });
    },

    rebindValidation: function () {
        if (window.jQuery && $.validator) {
            const form = document.querySelector("#taskModalBody form");
            if (form) $.validator.unobtrusive.parse(form);
        }
    },

    handleTagValidation: function (e) {
        if (e.target.classList.contains('tag-checker')) {
            const group = e.target.closest('.tag-checkbox-group');
            const checkedCount = group.querySelectorAll('.tag-checker:checked').length;
            const errorSpan = document.getElementById('TagError');
            const submitBtn = document.querySelector('button[type="submit"]');
            const isInvalid = checkedCount > 4;
            if (errorSpan) errorSpan.classList.toggle('d-none', !isInvalid);
            if (submitBtn) submitBtn.disabled = isInvalid;
        }
    },

    initFooterTips: function () {
        const tipText = document.getElementById("productivity-tip");
        const rerollBtn = document.getElementById("reroll-tip");
        if (!rerollBtn || !tipText) return;

        rerollBtn.addEventListener("click", () => {
            let newTip;
            do {
                newTip = AppConfig.ProductivityTips[Math.floor(Math.random() * AppConfig.ProductivityTips.length)];
            } while (newTip === tipText.innerText);
            tipText.style.opacity = 0;
            setTimeout(() => {
                tipText.innerText = newTip;
                tipText.style.opacity = 1;
            }, 200);
        });
    }
};

const KanbanBoard = {
    init: function () {
        const columns = document.querySelectorAll('.kanban-column-body');
        columns.forEach(column => {
            new Sortable(column, {
                group: 'kanban',
                animation: 250,
                ghostClass: 'bg-light',
                onEnd: (evt) => this.handleTaskMove(evt)
            });
        });
        this.filterTasks(); // Initial run
    },

    filterTasks: function () {
        const query = document.getElementById('kanbanSearch')?.value.toLowerCase() || "";
        const priority = document.getElementById('priorityFilter')?.value || "";
        const cards = document.querySelectorAll('.task-card-wrapper');
        let matches = 0;

        cards.forEach(card => {
            const title = card.getAttribute('data-title');
            const cardPriority = card.getAttribute('data-priority');

            const matchesSearch = title.includes(query);
            const matchesPriority = priority === "" || cardPriority === priority;

            if (matchesSearch && matchesPriority) {
                card.classList.remove('filtered-out');
                card.classList.add('filtered-in');
                matches++;
            } else {
                card.classList.remove('filtered-in');
                card.classList.add('filtered-out');
            }
        });

        // Re-sort the DOM so matches are on top
        document.querySelectorAll('.kanban-column-body').forEach(col => {
            const children = Array.from(col.children);
            children.sort((a, b) => {
                const aIn = a.classList.contains('filtered-in') ? 0 : 1;
                const bIn = b.classList.contains('filtered-in') ? 0 : 1;
                return aIn - bIn;
            });
            children.forEach(child => col.appendChild(child));

            // Check for empty column visual
            const hasVisible = col.querySelectorAll('.task-card-wrapper.filtered-in').length > 0;
            col.querySelector('.kanban-empty-state')?.classList.toggle('d-none', hasVisible);
        });

        document.getElementById('matchCount').innerText = `Found ${matches} relevant tasks`;
    },

    handleTaskMove: function (evt) {
        const taskId = evt.item.getAttribute('data-id');
        const newStatus = evt.to.getAttribute('data-status');
        const newPosition = evt.newIndex;

        const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;

        fetch('/Tasks/UpdatePosition', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Requested-With': 'XMLHttpRequest',
                'RequestVerificationToken': token 
            },
            body: JSON.stringify({
                id: parseInt(taskId),
                newStatus: parseInt(newStatus),
                newPosition: newPosition,
                __RequestVerificationToken: token
            })
        })
            .then(response => {
                if (!response.ok) throw new Error("Sync failed.");

                if (newStatus == "2") {
                    evt.item.querySelector('.task-card').classList.add('task-completed');
                    const checkBtn = evt.item.querySelector('.btn-status-pill');
                    if (checkBtn) {
                        checkBtn.classList.replace('btn-outline-secondary', 'btn-success');
                        checkBtn.querySelector('i').classList.replace('bi-circle', 'bi-check-lg');
                    }
                } else {
                    evt.item.querySelector('.task-card').classList.remove('task-completed');
                }
            })
            .catch(err => {
                console.error("Board Sync Error:", err);
                Swal.fire('Error', 'Failed to save position. Please refresh.', 'error');
            });
    }
};

const RoadmapPlanner = {
    toggleTask: function (taskId, actionId) {
        const card = document.getElementById(`planner-card-${taskId}`);
        if (!card) return;

        const isSelected = card.classList.contains('selected');
        const url = isSelected ? '/Roadmap/UnlinkTask' : '/Roadmap/LinkTask';
        const params = isSelected ? `taskId=${taskId}` : `taskId=${taskId}&actionId=${actionId}`;

        fetch(`${url}?${params}`, {
            method: 'POST',
            headers: { 'X-Requested-With': 'XMLHttpRequest' }
        })
            .then(response => {
                if (response.ok) {
                    card.classList.toggle('selected');
                } else {
                    alert("Failed to update task linkage.");
                }
            })
            .catch(err => console.error("Planner Error:", err));
    },

    deleteTaskPermanently: function (taskId) {
        if (!confirm("Are you sure? This will delete the task from your database entirely.")) return;

        fetch(`/Tasks/Delete/${taskId}`, {
            method: 'POST',
            headers: { 'X-Requested-With': 'XMLHttpRequest' }
        })
            .then(response => {
                if (response.ok) {
                    const item = document.getElementById(`task-item-${taskId}`);
                    if (item) {
                        item.style.opacity = '0';
                        setTimeout(() => item.remove(), 300);
                    }
                    const plannerCard = document.getElementById(`task-wrapper-${taskId}`);
                    if (plannerCard) {
                        plannerCard.style.opacity = '0';
                        setTimeout(() => plannerCard.remove(), 300);
                    }
                } else {
                    alert("Could not delete task.");
                }
            });
    },

    dismissLocally: function (taskId) {
        const wrapper = document.getElementById(`task-wrapper-${taskId}`);
        if (wrapper) {
            wrapper.style.opacity = '0';
            wrapper.style.transform = 'scale(0.8)';
            setTimeout(() => wrapper.remove(), 300);
        }
    }
};

document.addEventListener("DOMContentLoaded", () => TaskManager.init());