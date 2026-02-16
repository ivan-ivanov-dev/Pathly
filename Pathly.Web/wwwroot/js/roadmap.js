function confirmRoadmap() {
    const modal = new bootstrap.Modal(document.getElementById('saveModal'));
    modal.show();
}

function finalSubmit() {
    document.getElementById('roadmapForm').submit();
}

function triggerMajesticSave() {
    Swal.fire({
        title: 'Confirm Strategy?',
        text: "This will update your roadmap and milestones. Are you ready to proceed?",
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#0d6efd',
        cancelButtonColor: '#6c757d',
        confirmButtonText: 'Yes, Save Path',
        cancelButtonText: 'Review More',
        background: '#fff',
        customClass: {
            popup: 'rounded-4'
        }
    }).then((result) => {
        if (result.isConfirmed) {
            document.getElementById('roadmapForm').submit();
        }
    });
}

function showDeleteModal() {
    new bootstrap.Modal(document.getElementById('deleteConfirmModal')).show();
}

var RoadmapDetails = {
    unlinkTask: function (taskId, url) {
        const token = document.querySelector('input[name="__RequestVerificationToken"]').value;
        const element = document.getElementById(`task-item-${taskId}`);

        if (!element) return;

        element.style.opacity = "0.5";

        fetch(`${url}?taskId=${taskId}`, {
            method: 'POST',
            credentials: 'same-origin',
            headers: {
                'RequestVerificationToken': token,
                'X-Requested-With': 'XMLHttpRequest'
            }
        })
            .then(response => {
                if (response.ok) {
                    element.style.transition = "all 0.4s cubic-bezier(0.4, 0, 0.2, 1)";
                    element.style.transform = "translateX(40px)";
                    element.style.opacity = "0";

                    setTimeout(() => element.remove(), 400);
                } else {
                    element.style.opacity = "1";
                    alert("Server error: Could not unlink task.");
                }
            })
            .catch(err => {
                element.style.opacity = "1";
                console.error("Connection error:", err);
            });
    },
    toggleTaskStatus: function (taskId) {
        const token = $('input[name="__RequestVerificationToken"]').val();

        $.ajax({
            url: '/Roadmap/ToggleTaskStatus', // Adjust path to your controller
            type: 'POST',
            data: { id: taskId },
            headers: { "RequestVerificationToken": token },
            success: function (response) {
                if (response.success) {
                    const taskItem = $(`#task-item-${taskId}`);
                    const textSpan = taskItem.find('.task-title');

                    if (response.isCompleted) {
                        textSpan.addClass('text-decoration-line-through text-muted');
                        taskItem.addClass('task-completed');
                    } else {
                        textSpan.removeClass('text-decoration-line-through text-muted');
                        taskItem.removeClass('task-completed');
                    }
                }
            },
            error: function () {
                alert("Failed to update task status.");
            }
        });
    }
};
document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('textarea').forEach(el => {
        el.style.height = el.scrollHeight + 'px';
        el.addEventListener('input', function () {
            this.style.height = 'auto';
            this.style.height = (this.scrollHeight) + 'px';
        });
    });

    document.querySelectorAll('.action-card input').forEach(el => {
        el.addEventListener('focus', function () {
            this.closest('.action-card').style.borderTopColor = '#007bff';
        });
        el.addEventListener('blur', function () {
            this.closest('.action-card').style.borderTopColor = '#ffc107';
        });
    });
});