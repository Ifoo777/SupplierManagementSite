
//events
$(document).on("click", "#filterApply", ApplyFiltr)
//events end



//functions
function ApplyFiltr() { 
    var supplierUrl = $(this).data("url");
    var filterValue = $("#filter").val();
    window.location.href = supplierUrl + "?filter=" + filterValue;
}
//functions end