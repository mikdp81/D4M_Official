jQuery(document).ready(function () {

    $("#btnFiltra").click(function () {
        jQuery("#filtri").fadeToggle();   
    });

    $("#btnOrdina").click(function () {
        jQuery("#ordinamento").fadeToggle();
    });        
                   
});


function ApriFiltri() {
    jQuery("#filtri").show();    
}
function ApriOrdinamento() {
    jQuery("#ordinamento").show();
}

