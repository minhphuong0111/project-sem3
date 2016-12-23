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
                html += '<td> <input type="checkbox" name="your-group" value="' + value.svID + '" /> </td>';
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