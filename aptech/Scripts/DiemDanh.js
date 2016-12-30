var svarr = [];
var i = 0;
var mhm = "";

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
            mhm = $("#mhmID").val();
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
    
    var trangthaiarr = [];
    var lydoarr = [];
    for (var i = 0; i < svarr.length; i++)
    {
        var trangthai1 = $("input[name='" + svarr[i] + "']:checked").val();
        var lydo1 = $("#" + svarr[i]).val();
        /*var data = {
            trangthai : trangthai1,
            lydo : lydo1
        }
        dataarr[i] = data;
        */
        lydoarr[i] = lydo1;
        trangthaiarr[i] = trangthai1;
    }
    var ngay = $("#ngaythang").val();
    var frmData = new FormData();
    frmData.append("trangthai", trangthaiarr);
    frmData.append("lydo", lydoarr);
    frmData.append("ngaythang", ngay);
    frmData.append("svID", svarr);
    frmData.append("mhmID", mhm);

    //var model = JSON.stringify({ 'ds': dataarr });
 //   var postData = { values: dataarr };
    
    //var model = JSON.stringify(dataarr);
    $.ajax({
        url: "/DiemDanh/sendDD",
        contentType: false,
        processData: false,
        type: 'POST',
        
        data: frmData,
        success: function (rs) {
            alert(rs);
            window.location.assign(rs);
        },
        error: function (err) {
        alert("Error: " + err.responseText);
    }
    });
   
    
}


function _redirect(){
    window.location.assign("google.com");
}