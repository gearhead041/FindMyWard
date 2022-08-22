﻿
var dataTable;
$(document).ready( function () {
    var url = new URLSearchParams(location.search);
    var id = url.get("id");

    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url" : "/api/StudentInfo/Locations/"+ id,
            "type":"GET",
            "datatype":"json"
        },
        "columns":[
            {"data":"students.name","width" :"25%"},
            {"data": "students.matricNumber","width":"25%"},
            {"data": "students.user.email","width":"25%"},
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group">
                                <a href="/Admin/Student/Index?id=${data}" class="btn btn-success text-white"> 
                                    Detail
                                </a>
                                <a href="/Admin/Student/Delete?id=${data}" class="btn btn-danger text-white"> 
                                    Delete
                                </a>
                            </div>`
                },

                "width":"15%"
            }

            ],
            "width": "100%"
    });
});