$(document).ready(function () {

    $.ajaxSetup({ cache: false });

    $("#openDialog").on("click", function (e) {
       
        e.preventDefault();
        var url = $(this).attr('href');
        var theDialog = $("#dialog-edit").dialog({
            title: 'Create User',
            autoOpen: false,
            resizable: false,
            height: 450,
            width: 400,
            show: { effect: 'drop', direction: "up" },
            modal: true,
            draggable: true,
            open: function (event, ui) {
                $(this).load(url);
                $(".ui-dialog-titlebar-close").hide();
            }
        });
        theDialog.dialog("open");

        return false;
    });
});

