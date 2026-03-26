// 1. Handling the Create Form via AJAX
const createForm = document.getElementById('createTagForm');
if (createForm) {
    createForm.addEventListener('submit', function (e) {
        e.preventDefault();

        const form = this;
        const formData = new FormData(form);
        const errorSpan = document.getElementById('nameError');

        // Clear previous errors
        errorSpan.textContent = '';

        fetch(form.action, {
            method: 'POST',
            body: formData,
            headers: {
                'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
            }
        })
            .then(async response => {
                if (response.ok) {
                    window.location.reload();
                } else {
                    const errorMessage = await response.text();
                    errorSpan.textContent = errorMessage;
                    errorSpan.classList.add('text-danger');
                }
            })
            .catch(error => {
                console.error('Error:', error);
                errorSpan.textContent = 'Something went wrong. Please try again.';
            });
    });
}

// 2. Handling the Delete Confirmation
function confirmTagDelete(tagId, tagName) {
    Swal.fire({
        title: 'Delete Tag?',
        html: `Are you sure you want to remove <strong>#${tagName}</strong>?`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#ef4444',
        cancelButtonColor: '#6c757d',
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'Cancel',
        reverseButtons: true,
        borderRadius: '24px',
        customClass: {
            confirmButton: 'btn btn-danger px-4 mx-2 rounded-pill',
            cancelButton: 'btn btn-light px-4 mx-2 rounded-pill'
        },
        buttonsStyling: false
    }).then((result) => {
        if (result.isConfirmed) {
            const form = document.getElementById(`deleteForm-${tagId}`);
            if (form) {
                form.submit();
            } else {
                console.error("Delete form not found for ID:", tagId);
            }
        }
    });
}