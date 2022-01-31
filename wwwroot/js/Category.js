var table = null;
$(document).ready(function () {
    table = $('#example').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/Category/LoadCategoryMaster",
            "type": "POST"
        },
        "columns": [
            { "data": "id", title: "Category ID", name: "ID" },
            { "data": "name", title: "Category Name", name: "Name" },
            {
                "data": "id", title: "Action", name: "Action", "render":
                    function (data, type, full, meta) {
                        return "<button class='btnUpdate btn btn-secondary'>Update</button> <button class=' btn btn-danger btnDelete'>Delete</button>"
                    }
            },
        ],
    });
});

$(document).on("click", ".btnDelete", function () {
    var data = table.row($(this).parents('tr')).data();
    $.ajax({
        type: "Delete",
        url: "/Category/DeleteCategory?id=" + data.id,
        cache: false,
        success: function (data) {
            if (data.success) {
                table.ajax.reload();
                alert("Record Deleted Successfully!!!");
            } else {
                alert("Something Went Wrong!!!");
            }
        }
    });
});

$(document).on("click", ".btnUpdate", function () {
    var data = table.row($(this).parents('tr')).data();
    $.ajax({
        type: "POST",
        url: "/Category/AddCategory",
        data: { Id: data.id, Name: data.name},
        cache: false,
        success: function (data) {
            $("#myModal").html(data);
            $('#myModal').modal('show');
        }
    });
});

$(document).on("click", "#btnCreate", function () {
    $.ajax({
        type: "POST",
        url: "/Category/AddCategory",
        data: { Id:0, Name: '' },
        cache: false,
        success: function (data) {
            $("#myModal").html(data);
            $('#myModal').modal('show');
        }
    });
});



$(document).on("click", "#btnSave", function () {
    $.ajax({
        type: "POST",
        url: "/Category/SaveAddCategory",
        data: { Id: +$('#hdnCategoryID').val(), Name: $('#txtCategoryName').val()},
        cache: false,
        success: function (data) {
            if (data.success) {
                $('#myModal').modal('hide');
                table.ajax.reload();
                alert("Record Added/Updated Successfully!!!");
            } else {
                alert("Something Went Wrong!!!");
            }
        }
    });
});