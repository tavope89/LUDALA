/*
Función generica que realiza los llamados Ajax de todas las Funciones
en las pantallas de Valores Catálogo, a está se le pasan por parametro
la url que contiene la accion y el controller que se desean solicitar(url),
el nombre del método al que se desea llamar después del llamado Ajax(nombreMetodoEjecutar,
esté método recibirá el response),nota el formato del response debe tener el siguiente formato:

También otro parámetro necesario es el JSONstringify lo cual corresponde a los parametros
que recibirá el controller, el cual deberá tener el formato:

JSON.stringify({ objeto1: valor1, objeto2: valor2 });

En caso de Error el Ajax redigira a una pantalla de error con el botón para 
redirecionar al Index.
*/
function EjecutarAjax(url, nombreMetodoEjecutar, sJSONstringify) {

    var d = 0;

    jQuery.ajax({
        url: url,
        /*cache: false,*/
        type: "POST",
        data: sJSONstringify,
        dataType: "json",
        contentType: "application/json",
        success: function (response) {
            /*window[nombreMetodoEjecutar](response);*/
            AgregarDivReedFeed(response);
        },
        error: function (jqXhr, textStatus, errorThrown) {
            window.location.href = window._urlIndex;
        },
        async: true,
       /* processData: false*/
    });
}

function AgregarDivReedFeed(response) {

    $('#Titulo').val(response.Titulo);
    var html = "";
    var ul = document.getElementById("items");
    for (var i = 0; i < response.Articulos.length; i++) {
        
        var li = document.createElement("li");
        
        var link = document.createElement("a");
        link.setAttribute("href", response.Articulos[i].Link);
        var titulo = document.createTextNode(response.Articulos[i].Titulo);
        link.appendChild(titulo);
        var h2 = document.createElement("h2");
        h2.appendChild(link);
        
        var p = document.createElement("p");
        var fecha = document.createTextNode(response.Articulos[i].FechaPublicacion);
        var autor = document.createTextNode(response.Articulos[i].Autor);
        p.appendChild(fecha);
        p.appendChild(autor);
        
        var div = document.createElement("div");
        div.innerHTML = response.Articulos[i].Contenido;
        
        li.appendChild(h2);
        li.appendChild(p);
        li.appendChild(div);
        ul.appendChild(li);
    }
    //var contenido = $('#items');
    
}



