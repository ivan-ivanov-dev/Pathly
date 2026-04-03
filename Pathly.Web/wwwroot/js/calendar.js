let calendar;

document.addEventListener('DOMContentLoaded', function () {
    const calendarEl = document.getElementById('calendar');
    calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,listWeek'
        },
        events: '/Calendar/GetEvents',
        eventClick: (info) => openEditModal(info.event.id),
        height: 'auto',
        editable: true
    });
    calendar.render();
});

function openCreateModal() {
    fetch('/Calendar/Create')
        .then(r => r.text())
        .then(html => {
            document.getElementById('modalContent').innerHTML = html;
            new bootstrap.Modal(document.getElementById('eventModal')).show();
        });
}

function openEditModal(id) {
    fetch(`/Calendar/Edit/${id}`)
        .then(r => r.text())
        .then(html => {
            document.getElementById('modalContent').innerHTML = html;
            new bootstrap.Modal(document.getElementById('eventModal')).show();
        });
}

function handleFormSubmit(form, e) {
    e.preventDefault();
    const errorContainer = document.querySelector('.partial-error-container');
    const errorText = document.getElementById('errorText');

    // Reset errors
    if (errorContainer) errorContainer.style.display = 'none';

    fetch(form.action, { method: 'POST', body: new FormData(form) })
        .then(async response => {
            if (response.ok) {
                bootstrap.Modal.getInstance(document.getElementById('eventModal')).hide();
                calendar.refetchEvents();
                Swal.fire({ icon: 'success', title: 'Saved', timer: 1000, showConfirmButton: false });
            } else {
                const msg = await response.text();
                if (errorContainer) {
                    errorText.innerText = msg;
                    errorContainer.style.display = 'block';
                } else {
                    Swal.fire({ icon: 'error', title: 'Error', text: msg });
                }
            }
        })
        .catch(() => Swal.fire('Error', 'Server connection failed', 'error'));
}

function confirmDelete(id) {
    Swal.fire({
        title: 'Delete Event?',
        text: 'This action cannot be undone.',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#E36414',
        confirmButtonText: 'Delete'
    }).then((res) => {
        if (res.isConfirmed) {
            fetch(`/Calendar/Delete/${id}`, { method: 'POST' })
                .then(r => {
                    if (r.ok) {
                        bootstrap.Modal.getInstance(document.getElementById('eventModal')).hide();
                        calendar.refetchEvents();
                    }
                });
        }
    });
}