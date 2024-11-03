//jQuery('document').ready(function () {

//    $table1 = jQuery('#table_row');
//    $table1.find('thead tr').append('<th> experience </th>');
//    $table1.find('tbody tr').each(function () {
//        var sum = 0;
//        const d = new Date();
//        var year = d.getFullYear();

//        jQuery(this).append('<td class="experience">' + year + '</td>');


//    });

//    $("#table_row").find("tbody tr").each(function (index, element) {
//        var a = $(element).find(".joiningDate").text();
//        var test1 = new Date();
//        var test2 = new Date(a);
//        $(element).find(".experience").text(test1.getFullYear() - test2.getFullYear());
//    })
 

 

//    console.log($("#table_row"));


//    //var tbl = document.getElementById('table_row');
//    //var lastRow = tbl.rows.length;


//});
function () {

    $table1 = jQuery('#table_row');
    $table1.find('thead tr').append('<th> experience </th>');
    $table1.find('tbody tr').each(function (index, element) {
        var sum = 0;
        const d = new Date();
        var year = d.getFullYear();
        var a = $(element).find(".joining_date").text();
        const test1 = new Date();
        var test2 = new Date(a);
        var year = test1.getFullYear() - test2.getFullYear();

        jQuery(this).append('<td class="experience">' + year/*.fontcolor("black")*/ + " " + 'years' + '</td>');


    });


};

/*jQuery('document').ready(function () {
    $table1 = jQuery('#table_row');
    $table1.find('thead tr').append('<th> net_salary </th>');
    $table1.find('thead tr').append('<th> pf_deduction </th>');
    $table1.find('thead tr').append('<th> Insurance </th>');
    $table1.find('tbody tr').each(function () {
        var sum = 55;
        jQuery(this).find('td').each(function (index, element) {
           // if ((Number(jQuery(this).text()))) {
             sum = $(element).find(".salary").text(new Date());
            //}
        });
        jQuery(this).append('<td>' + sum + '</td>');
        jQuery(this).append('<td>' + avg + '</td>');
        jQuery(this).append('<td>' + avg + '</td>');
    });
});
*/

