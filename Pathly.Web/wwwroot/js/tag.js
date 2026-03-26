document.addEventListener('DOMContentLoaded', function () {
    const createModal = document.getElementById('createTagModal');
    if (createModal) {
        createModal.addEventListener('shown.bs.modal', function () {
            const nameInput = createModal.querySelector('input[name="Name"]');
            if (nameInput) nameInput.focus();
        });
    }

    const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
});

@param { number } tagId
@param { string } tagName

function confirmTagDelete(tagId, tagName) {
    Swal.fire({
        title: 'Delete Tag?',
        html: `Are you sure you want to remove <strong>#${tagName}</strong>?<br><small class="text-muted">This action cannot be undone.</small>`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#ef4444', 
        cancelButtonColor: '#6c757d',
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'Cancel',
        reverseButtons: true,
        background: '#fff',
        color: '#1a202c',
        borderRadius: '24px',
        showClass: {
            popup: 'animate__animated animate__fadeInUp animate__faster'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutDown animate__faster'
        },
        customClass: {
            confirmButton: 'btn btn-danger px-4 py-2 rounded-pill fw-bold mx-2',
            cancelButton: 'btn btn-light px-4 py-2 rounded-pill fw-bold mx-2'
        },
        buttonsStyling: false 
    }).then((result) => {
        if (result.isConfirmed) {
            const card = document.getElementById(`deleteForm-${tagId}`).closest('.inverted-tag-card');
            if (card) {
                card.style.transition = 'all 0.4s ease';
                card.style.opacity = '0';
                card.style.transform = 'scale(0.9)';
            }

            setTimeout(() => {
                document.getElementById(`deleteForm-${tagId}`).submit();
            }, 300);
        }
    });
}
