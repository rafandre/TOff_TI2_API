//Fotografias dos Realizadores 
function imageRealizador(result) {
    var div_holder_img = $("<div>");
    div_holder_img.css({ border: "solid", borderColor: "black" });

    var img = $("<img>");
    div_holder_img.append(img);
    img.attr("src", "ImagensRealizadores/" + result.id + result.imagem);
    img.attr("width", "285");
    img.attr("height", "413");

    return div_holder_img;
}

//Nome e Data de Nasciemento do Realizador 
function Realizador(result) {
    var div_holder_info = $("<div>");
    //div_holder.append(div_holder_info);

    var div_nome = $("<div>");
    div_holder_info.append(div_nome);
    div_nome.addClass("nome");
    div_nome.text(result.nome);

    var div_ano = $("<div>");
    div_holder_info.append(div_ano);
    div_ano.css({ marginLeft: "150px" });

    var div_anoTexto = $("<h3>");
    div_ano.append(div_anoTexto);
    div_anoTexto.css({ fontFamily: "Arial", fontWeight: "bold", color: "black" });
    div_anoTexto.text(result.ano);

    return div_holder_info;
}

//Biografia do Realizador 
function Biografia(result) {

    var div_sinopse = $("<div>");
    //div_holder_All.append(div_sinopse);
    div_sinopse.addClass("sinopse");

    var h3_titSinopse = $("<h3>");
    div_sinopse.append(h3_titSinopse);
    h3_titSinopse.css({ fontFamily: "Arial", fontWeight: "bold", color: "darkred" });
    h3_titSinopse.text("Sinopse");

    var span_sinopse = $("<span>");
    div_sinopse.append(span_sinopse);
    span_sinopse.text(result.sinopse);

    return div_sinopse
}
