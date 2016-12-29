$(document).ready(function () {
    _getAll();
});
isUpdate = false;
function _getAll() {
    $.ajax({
        url: "MonHoc/layMonHoc/",
        type: "GET",
        dataType: "json",
        success: function (data) {
            var html = '';
            
            $.each(data, function (key,value) {
               
                html += '<tr>';
                html += '<td>' + value.mhID + '</td>';
                html += '<td>' + value.mhTen + '</td>';
                html += '<td><button type="button" onclick="return _getById(' + "'"+value.mhID+"'" + ');">Edit</button> | <a href="#" onclick="return _delete(' + "'" + value.mhID + "'" + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('#ds tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

    $('#btnEdit').hide();
    $('#btnSave').show();
    return false;
}
function _getById(id) {
    $("#btnSave").hide();
    $("#btnEdit").show();
    $.ajax({
        
        url: '/MonHoc/layMonHocID/' + id,
        // data: JSON.stringify(dto),
        
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, value) {
                $('#mhid').val(value.mhID);
                $('#mhten').val(value.mhTen);

                isUpdate = true;
                $('#mhid').prop("disabled", true);
                $("#bookModal").modal('show');
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    
    return false;
}
function _add() {
    var obj = {
        StudentId: $('#StudentId').val(),
        Name: $('#Name').val(),
        Status: $('#Status').val(),
    }
    $.ajax({
        url: '/MonHoc/themMH',
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
           
            _getAll();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function _edit() {
    var obj = {
        StudentId: $('#StudentId').val(),
        Name: $('#Name').val(),
        Status: $('#Status').val(),
    }
    $.ajax({
        url: '/MonHoc/suaMH',
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (result) {
            _getAll();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function _delete(id) {
    var cf = confirm('Are you sure want to permanently delete this row?');
    if (cf) {
        $.ajax({
            url: '/MonHoc/xoaMH/' + id,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (result) {
                _getAll();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

// hàm Insert và Update một record
function _btnAdd()
{
    
    var data = {
        mhID: $("#mhid").val(),
        mhTen: $("#mhten").val(),

    }
    
        
    $.ajax({
        url: 'MonHoc/themMH/',
        type: 'POST',
        dataType: 'json',
        data: data,
        success: function (data) {
            alert('afjksl');
            _getAll();
            $("#bookModal").modal('hide');
            clear();
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
function _btnEdit()
{
    $("#btnEdit").show();
    var data = {
        mhID: $("#mhid").val(),
        mhTen: $("#mhten").val(),

    }
    
    $.ajax({
        url: 'MonHoc/suaMH/',
        type: 'POST',
        dataType: 'json',
        data: data,
        success: function (data) {
            _getAll();
            isUpdatable = false;
            $("#bookModal").modal('hide');
            clear();
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
    $("#btnSave").show();
    $("#btnEdit").hide();
}
    
