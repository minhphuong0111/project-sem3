var svarr = [];
var i = 0;

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
                html += '<td> <input type = "radio" value="kp"  name="' + value.svID + '" /> </td>';
                html += '<td> <input type = "radio" value="cp"  name="' + value.svID + '" /> </td>';
                html += '<td> <input type="text" id="' + value.svID + '" disabled="disabled" /> </td>';
                html += '</tr>';
                svarr[i] = value.svID;
                i++;
            });
            $('#ds tbody').html(html);
            $("input").on("click", function () {
                txtname = $(this).attr("name");
                if ($(this).val() == "cp") {                    
                    $("#" + txtname).prop("disabled", false);
                }
                else {
                    $("#" + txtname).prop("disabled", true);
                }
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}



/*
$(function () {
    $("form input:radio").on('click', function () {
        // in the handler, 'this' refers to the box clicked on
        var $box = $(this);
        if ($box.is(":checked")) {
            // the name of the box is retrieved using the .attr() method
            // as it is assumed and expected to be immutable
            var group = "input:radio[name='" + $box.attr("name") + "']";

            // the checked state of the group/box on the other hand will change
            // and the current value is retrieved using .prop() method
            $(group).prop("checked", false);
            $box.prop("checked", true);
            
        } else {
            $box.prop("checked", false);
        }
        alert($("input[name='" + $box.attr("name") + "']:checked").val());

        if($("input[name='" + $box.attr("name") + "']:checked").val() == 'cp')
        {
            alert('fdfs');
        }
        
    });
});
*/
function jsonObj(class_t, type_t) {
    this.trangthai = class_t;
    this.lydo = type_t;
}

function _tbdata() {
    
    var dataarr = [];
    
    for(var i = 0; i<svarr.length; i++)
    {
        var trangthai = $("input[name='" + svarr[i] + "']:checked").val();
        var lydo = $("#" + svarr[i]).val();
       /* dataarr[i] = new Array(2);
        dataarr[i][0] = trangthai;
        dataarr[i][1] = lydo;*/
        dataarr[i] = ["" + trangthai, "" + lydo];
        
    }
    myDataObject = new Object;
    myDataObject.jsonObj = dataarr;
    $.ajax({
        type: "POST",
        url: "DiemDanh/guiDiemDanh",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        traditional: true,
        data: { id: JSON.stringify(myDataObject) },
        success: function (result) {
        },
        error: function (data, textStatus) { alert(textStatus); }
    });
   
}


function _redirect(){
    window.location.assign("google.com");
}