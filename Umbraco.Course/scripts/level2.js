$(function () {

    $('a.pop').popover({ trigger: "hover", placement: "top" });

    $('#stream a[data-status-id]').click(function () {

        var id = $(this).attr('data-status-id');

        var likesElement = $(this).parent().find('span');

        $.get("/umbraco/api/likes/likestatus", { id: id },

            function (data) {
                $(likesElement).html(data);
            });

        return false;
    });

});