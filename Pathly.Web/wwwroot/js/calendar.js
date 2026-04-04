let calendar;

document.addEventListener('DOMContentLoaded', function () {
    const calendarEl = document.getElementById('calendar');

    if (!calendarEl) {
        console.error("Calendar element not found in the DOM.");
        return;
    }

    calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,listWeek'
        },
        events: '/Calendar/GetEvents',
        editable: true,
        height: 'auto',
        selectable: true,
        nowIndicator: true,
        dayMaxEvents: true,

        eventDataTransform: function (eventData) {
            return {
                id: eventData.id || eventData.Id,
                title: eventData.title || eventData.Title,
                start: eventData.start || eventData.Start,
                end: eventData.end || eventData.End,
                allDay: eventData.allDay || eventData.AllDay,
                extendedProps: {
                    Color: eventData.color || eventData.Color || eventData.colorHex,
                    Description: eventData.description || eventData.Description,
                    GoalTitle: eventData.goalTitle || "",
                    TaskTitle: eventData.taskTitle || ""
                }
            };
        },

        eventContent: function (arg) {
            const title = arg.event.title || "Untitled";
            const color = arg.event.extendedProps.Color || "#0F4C5C";
            const goalTitle = arg.event.extendedProps.GoalTitle;
            const taskTitle = arg.event.extendedProps.TaskTitle;

            const timeStr = arg.event.start ? arg.event.start.toLocaleTimeString([], {
                hour: '2-digit', minute: '2-digit', hour12: true
            }) : "";

            let html = `
                <div class="premium-event-wrapper" style="--accent-color: ${color}">
                    <div class="event-accent-bar"></div>
                    <div class="event-content-body">
                        <div class="event-meta-top">
                            <span class="event-time-badge">${timeStr}</span>
                            <div class="event-icons">
                                ${goalTitle ? `<i class="bi bi-target2 linked-icon goal" title="Linked to Goal: ${goalTitle}"></i>` : ''}
                                ${taskTitle ? `<i class="bi bi-check2-circle linked-icon task" title="Linked to Task: ${taskTitle}"></i>` : ''}
                                <i class="bi bi-x-circle-fill event-delete-btn" onclick="event.stopPropagation(); confirmDelete('${arg.event.id}')"></i>
                            </div>
                        </div>
                        <div class="event-main-title">${title}</div>
                    </div>
                </div>
            `;
            return { html: html };
        },

        eventClick: function (info) {
            const eventId = info.event.id;

            if (!eventId || eventId === "0") {
                console.warn("Invalid ID detected:", eventId);
                Swal.fire('Context Error', 'The event ID is missing. Please refresh.', 'error');
                return;
            }

            openEditModal(eventId);
        },

        eventDrop: function (info) {
            updateEventTimes(info.event);
        },
        eventResize: function (info) {
            updateEventTimes(info.event);
        }
    });

    calendar.render();
});

/* ==========================================================================
   MODAL & FORM MANAGEMENT
   ========================================================================== */

function openCreateModal() {
    const modalContent = document.getElementById('modalContent');

    fetch('/Calendar/Create')
        .then(response => {
            if (!response.ok) throw new Error('Network response was not ok');
            return response.text();
        })
        .then(html => {
            modalContent.innerHTML = html;
            const modal = new bootstrap.Modal(document.getElementById('eventModal'));
            modal.show();
            initializeTooltips();
        })
        .catch(err => Swal.fire('Error', 'Could not load the creation form.', 'error'));
}

function openEditModal(id) {
    const modalContent = document.getElementById('modalContent');

    fetch(`/Calendar/Edit/${id}`)
        .then(response => {
            if (!response.ok) throw new Error('Unauthorized or Not Found');
            return response.text();
        })
        .then(html => {
            modalContent.innerHTML = html;
            const modal = new bootstrap.Modal(document.getElementById('eventModal'));
            modal.show();
        })
        .catch(err => {
            console.error(err);
            Swal.fire('Access Denied', 'You do not have permission to edit this event.', 'error');
        });
}

function handleFormSubmit(form, e) {
    e.preventDefault();

    const errorContainer = document.querySelector('.partial-error-container');
    const errorText = document.getElementById('errorText');
    const submitBtn = form.querySelector('button[type="submit"]');

    if (errorContainer) errorContainer.style.display = 'none';
    if (submitBtn) submitBtn.disabled = true;

    fetch(form.action, {
        method: 'POST',
        body: new FormData(form)
    })
        .then(async response => {
            if (response.ok) {
                const modalEl = document.getElementById('eventModal');
                const modalInstance = bootstrap.Modal.getInstance(modalEl);
                if (modalInstance) modalInstance.hide();

                calendar.refetchEvents();
                Swal.fire({
                    icon: 'success',
                    title: 'Pathly Updated',
                    text: 'Your schedule has been synchronized.',
                    timer: 1500,
                    showConfirmButton: false
                });
            } else {
                const msg = await response.text();
                if (errorContainer) {
                    errorText.innerText = msg;
                    errorContainer.style.display = 'block';
                } else {
                    Swal.fire({ icon: 'error', title: 'Action Failed', text: msg });
                }
            }
        })
        .catch(() => Swal.fire('Connection Error', 'Server is unreachable.', 'error'))
        .finally(() => {
            if (submitBtn) submitBtn.disabled = false;
        });
}

/* ==========================================================================
   DELETION & UTILITIES
   ========================================================================== */

function confirmDelete(id) {
    Swal.fire({
        title: 'Remove Event?',
        text: 'This milestone will be permanently removed from your path.',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#E36414',
        cancelButtonColor: '#6c757d',
        confirmButtonText: 'Yes, remove it',
        background: '#ffffff',
        backdrop: `rgba(15, 76, 92, 0.4)`
    }).then((res) => {
        if (res.isConfirmed) {
            fetch(`/Calendar/Delete/${id}`, { method: 'POST' })
                .then(r => {
                    if (r.ok) {
                        const modalEl = document.getElementById('eventModal');
                        const modalInstance = bootstrap.Modal.getInstance(modalEl);
                        if (modalInstance) modalInstance.hide();

                        calendar.refetchEvents();
                        Swal.fire({ icon: 'success', title: 'Removed', timer: 1000, showConfirmButton: false });
                    } else {
                        Swal.fire('Error', 'Delete failed. Access denied.', 'error');
                    }
                });
        }
    });
}

$(document).on('change', 'input[name="Start"]', function () {
    let startVal = new Date($(this).val());
    let endInput = $('input[name="End"]');

    if (!isNaN(startVal.getTime())) {
        startVal.setHours(startVal.getHours() + 1);

        let year = startVal.getFullYear();
        let month = String(startVal.getMonth() + 1).padStart(2, '0');
        let day = String(startVal.getDate()).padStart(2, '0');
        let hours = String(startVal.getHours()).padStart(2, '0');
        let mins = String(startVal.getMinutes()).padStart(2, '0');

        let formattedEnd = `${year}-${month}-${day}T${hours}:${mins}`;
        endInput.val(formattedEnd);
    }
});

function initializeTooltips() {
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
}

window.addEventListener('unhandledrejection', function (event) {
    console.error('Unhandled promise rejection:', event.reason);
});