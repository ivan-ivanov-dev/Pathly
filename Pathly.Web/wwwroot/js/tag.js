$(document).ready(function () {
    const createModal = $('#createTagModal');
    const createForm = $('#createTagForm');
    const nameError = $('#nameError');

    // FIX 1: Reset modal when closed
    createModal.on('hidden.bs.modal', function () {
        createForm[0].reset();             // Clear inputs
        nameError.empty().hide();          // Clear AJAX errors
        $('.custom-val-msg').empty();      // Clear standard validation
    });

    // 2. Handle Tag Creation via AJAX
    createForm.on('submit', function (e) {
        e.preventDefault();

        nameError.empty().hide();

        $.ajax({
            url: $(this).attr('action'),
            type: 'POST',
            data: $(this).serialize(),
            success: function () {
                // FIX 2: Close modal and refresh page to show new tag
                const modalInstance = bootstrap.Modal.getInstance(createModal[0]);
                modalInstance.hide();
                location.reload();
            },
            error: function (xhr) {
                const response = xhr.responseJSON;
                if (response && response.errors) {
                    // FIX 3: Show as red text above input
                    // We only take the first error to avoid "doubling"
                    nameError.text(response.errors[0]).show();
                }
            }
        });
    });

    // 3. Handle Tag Deletion via AJAX
    $(document).on('click', '.btn-delete-tag', function (e) {
        e.preventDefault();
        const btn = $(this);
        const form = btn.closest('form');
        const card = btn.closest('.tag-card');

        $.ajax({
            url: form.attr('action'),
            type: 'POST',
            data: form.serialize(),
            success: function () {
                card.fadeOut(400, function () {
                    $(this).remove();
                    if ($('.tag-card').length === 0) location.reload();
                });
            }
        });
    });
});