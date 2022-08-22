var dataTable;
$(document).ready( function () {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url" : "/api/Locations",
            "type":"GET",
            "datatype":"json"
        },
        "columns":[
            {"data":"name","width" :"25%"},
            {"data": "genderGroup","width":"25%"},
            {"data": "students.length","width":"25%"},
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group">
                                <a href="/Admin/Locations/Detail?id=${data}" class="btn btn-success text-white"> 
                                    Detail
                                </a>
                                <a onClick=Delete('/api/Locations/'+${data}) class="btn btn-danger text-white"> 
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

function Delete(url) {
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
}).then((result) => {
  if (result.isConfirmed) {
      $.ajax({
          url:url,
          type:'DELETE',
          success: function (data) {
              if (data.success) {
                  //HACK Reload not working?
                  dataTable.ajax.reload();
                  toastr.success(data.message);
              }
              else {
                  toastr.failure(data.message);
              }
          }
      })
     
  }
})}