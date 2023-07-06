//import { Number } from "core-js";

function validaEmail(email) {

    var regexp = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (email != "") {
        var boo = regexp.test(email);
        if (boo) {
            return "";
        }
        else {
            return "L'email non ha un formato corretto; <br>";
        }
    }
}

function validaNum(numero, campoErr) {

    if (numero != "") {
    if (!isNaN(numero)) {
    //if (true) {
        return "";
    } else {
        return "Inserire solo numeri nel campo" + campoErr + "; <br>";
    }
    }

}


function validaCAP(cap) {

    var regexp = /^\d{5}$/;
    if (cap != "") {
        var boo = regexp.test(cap);
        if (boo) {
            return "";
        }
        else {
            return "Il CAP deve essere un campo numerico di 5 cifre; <br>";
        }
    }
}




function validaCF(cf) {

    var regexp = /^[a-zA-Z]{6}[0-9]{2}[a-zA-Z][0-9]{2}[a-zA-Z][0-9]{3}[a-zA-Z]$/;
    var regexp2 = /^[0-9]{11}$/;

    if (cf != "") {
        var boo = regexp.test(cf);
        var boo2 = regexp2.test(cf);
        if (boo || boo2) {
            return "";
        }
        else {
            return "Il Codice Fiscale deve essere un campo di 11 o 16 cifre; <br>";
        }
    }



}