function _getSV(mhmID)
{
    $.ajax({
        type: "GET",
        url: "DiemDanh/lstSV/",
        dataType: "json",
        data: { mhmID: $("#mhmID").val() },
        success: function (data) {
            var html = '';
            $.each(data, function (key, value) {
                html += '<tr>';
                html += '<td>' + value.svID + '</td>';
                html += '<td>' + value.svTen + '</td>';
                html += '<td>' + value.lopID + '</td>';
                html += '<td> <input type = "radio" checked value="cm" name="' + value.svID + '" /> </td>';
                html += '<td> <input type = "radio" value="cp"  name="' + value.svID + '" /> </td>';
                html += '<td> <input type = "radio" value="kp"  name="' + value.svID + '" /> </td>';
                html += '<td> <input type="text" id="' + value.svID + '" disabled="disabled" /> </td>';
                html += '</tr>';
            });
            $('#ds tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

$(function () {
    $("input:checkbox").on('click', function () {
        // in the handler, 'this' refers to the box clicked on
        var $box = $(this);
        if ($box.is(":checked")) {
            // the name of the box is retrieved using the .attr() method
            // as it is assumed and expected to be immutable
            var group = "input:checkbox[name='" + $box.attr("name") + "']";
            // the checked state of the group/box on the other hand will change
            // and the current value is retrieved using .prop() method
            $(group).prop("checked", false);
            $box.prop("checked", true);
        } else {
            $box.prop("checked", false);
        }
        if($('input[name="'+ $box.attr("name") +'"]:checked').val() == "cp")
        {
            var group1 = "input:text[id='" + $box.attr("id") + "']";
            document.getElementById(group1).disabled = false;
        }
    });
});
