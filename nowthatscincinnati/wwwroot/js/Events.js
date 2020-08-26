$(document).ready(function () {
    // Create Event
    $('#create-event-btn').click(function () {
        var modal = $('#create-event-modal');
        var url = $(this).data('url');

        $.get(url, function (data) {
            $('#create-event-modal-content').html(data);
            modal.show();

            $('#create-event-back-btn').on('click', function () {
                modal.hide();
            });
            
            UpdateFileName();
        });
    });

    // Edit Event
    EditEvent();

    function EditEvent() {
        $('.edit-event-btn').click(function () {
            var modal = $('#edit-event-modal');
            var url = $(this).data('url');

            $.get(url, function (data) {
                $('#edit-event-modal-content').html(data);
                modal.show();

                $('#edit-event-back-btn').on('click', function () {
                    modal.hide();
                });

                $('#details-event-modal').hide();

                UpdateFileName();
            });
        });
    }

    // Delete Event
    $('.delete-event-btn').click(function () {
        var modal = $('#delete-event-modal');
        var url = $(this).data('url');

        $.get(url, function (data) {
            $('#delete-event-modal-content').html(data);
            modal.show();

            $('#delete-event-back-btn').on('click', function () {
                modal.hide();
            });
        });
    });

    // Details Event
    $('.details-event-btn').click(function () {
        var modal = $('#details-event-modal');
        var url = $(this).data('url');

        $.get(url, function (data) {
            $('#details-event-modal-content').html(data);
            modal.show();

            $('#details-event-back-btn').on('click', function () {
                modal.hide();
            });

            EditEvent();
        });
    });

    // Helper Functions
    function UpdateFileName() {
        $('input[type="file"]').on('change', function (e) {
            var fileName = e.target.files[e.target.files.length - 1].name;
            $('.custom-file-label').html(fileName);
        });
    }
});