/*$(function () {

    $table1 = jQuery('#table_row');
   $table1.find('thead tr').append('<th> experience </th>');
   $table1.find('tbody tr').each(function (index,element) {
       var sum = 0;
       const d = new Date();
       var year = d.getFullYear();
       var a = $(element).find(".joining_date").text();
       const  test1 = new Date();
       var test2 = new Date(a);
       var year = test1.getFullYear() - test2.getFullYear();

       jQuery(this).append('<td class="experience">' + year*//*.fontcolor("black")*//* +" "+ 'years'+ '</td>');


   });

  
});*/
$("#test").click(function (e) {
    e.preventDefault();
    var popup = document.getElementById("myPopup");
    popup.classList.toggle("show");
});
function myFunction(e) {
    e.preventDefault();
}
/*$('#myForm').modal('show'*/
$('#btnShow').click(function () {
    $('#myForm').modal('show');
});
$('#btncreate').click(function () {
    $('#myFormcreate').modal('show');
});
/*$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus')
})*/



















/* $("#table_row").find("tbody tr").each(function (index, element) {
       console.log(element);
       var a = $(element).find(".joining_date").text();
       console.log(a);
       var test1 = new Date();
       var test2 = new Date(a);
      // $(element).find(".experience").text(test1.getFullYear());
       $(element).find(".experience").text(test1.getFullYear() - test2.getFullYear());

   })
*/
//gets table
/*  var oTable = document.getElementById('table_row');
  $oTable.find('thead tr').append('<th> experience </th>');
  //gets rows of table
  var rowLength = oTable.rows.length;

  //loops through rows    
  for (i = 0; i < rowLength; i++) {

      //gets cells of current row  
      var oCells = oTable.rows.item(i).cells;

      //gets amount of cells of current row
      var cellLength = oCells.length;

      //loops through each cell in current row
      for (var j = 0; j < cellLength; j++) {
          // get your cell info here

          var cellVal = oCells.item(j).innerHTML;
          console.log(cellVal);
      }
  }*/
/*
   $("#table_row").find("tbody tr").each(function (index, element) {
       var a = $(element).find(".joining_date").text();
        var test1 = new Date();
       var test2 = new Date(a);
       $(element).find(".experience").text(test1.getFullYear() );  
       //$(element).find(".experience").text(test1.getFullYear() - test2.getFullYear());

   })
*/


//console.log($("#table_row"));


/*var tbl = document.getElementById('table_row');*/
//var lastRow = tbl.rows.length;

