//Vai buscar a Imagem dos Filmes  
function ImageFilme(result) {
    var div_holder_img = $("<div>");
    div_holder_img.css({ border: "solid", borderColor: "black" });

    var img = $("<img>");
    div_holder_img.append(img);
    img.attr("src", "Imagens/" + result.id + result.imagem);
    img.attr("width", "285");
    img.attr("height", "413");
    return div_holder_img;
}

//Nome do Filme
function NomeFilme(result) {
    var div_nome = $("<div>");
    //div_holder_info.append(div_nome);
    div_nome.addClass("nome");
    div_nome.text(result.titulo);
    return div_nome;
}

//Ano do Filme 
function AnoFilme(result) {
    var div_ano = $("<div>");
    //div_holder_info.append(div_ano);
    div_ano.css({ marginLeft: "150px" });

    var div_anoTexto = $("<h3>");
    div_ano.append(div_anoTexto);
    div_anoTexto.css({ fontFamily: "Arial", fontWeight: "bold", color: "black" });
    div_anoTexto.text(result.ano);

    return div_ano;
}

//categorias dos Filmes 
function CategoriaFilme(result) {
    var div_categorias = $("<div>");
    //div_holder_info.append(div_categorias);
    div_categorias.css({ marginLeft: "150px" });
    var p_categorias = $("<p>");
    div_categorias.append(p_categorias);
    p_categorias.css({ fontFamily: "Arial", fontWeight: "bold", color: "black", fontSize: "18px" });
    var tempStringBuild = "";
    for (var i = 0; i < result.categoria.length; i++) {
        tempStringBuild += result.categoria[i].Nome;
        if (i < result.categoria.length - 1) tempStringBuild += ", ";
    }
    p_categorias.text(tempStringBuild);

    return div_categorias;
}

// Realizador do Filme
function RealizadorFilme(result) {
    var div_realizador = $("<div>");
    //div_holder_info.append(div_realizador);
    div_realizador.css({ marginLeft: "150px" });
    var h3_realizador = $("<h3>");
    div_realizador.append(h3_realizador);
    h3_realizador.css({ textDecoration: "underline", color: "Darkred", cursor: "pointer", fontFamily: "Arial", fontWeight: "bold", fontSize: "18px" });
    h3_realizador.text(result.realizadorNome);
    let idRealizador = result.realizador;
    h3_realizador.click(function () {
        loadRealizador(idRealizador);
    });

    return div_realizador;
}

//Atores do Filme 
function AtoresFilme(result) {
    var div_atores = $("<div>");
    //div_holder_info.append(div_atores);
    div_atores.css({ marginLeft: "150px" });
    var p_atores = $("<p>");
    div_atores.append(p_atores);
    p_atores.css({ fontFamily: "Arial", fontWeight: "bold", color: "black", fontSize: "15px" });
    tempStringBuild = "";
    for (var i = 0; i < result.atores.length; i++) {
        tempStringBuild += result.atores[i].Nome;
        if (i < result.atores.length - 1) tempStringBuild += ", ";
    }
    p_atores.text(tempStringBuild);

    return div_atores;
}

//Sinopse do Filme 
function SinopseFilme(result) {

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

    return div_sinopse;
}

//Trailer do Filme 
function TrailerFilme(result) {

    var div_trailler = $("<div>");
    //div_holder_All.append(div_trailler);

    var h3_trailler = $("<h3>");
    div_trailler.append(h3_trailler);
    h3_trailler.css({ fontFamily: "Arial", fontWeight: "bold", color: "darkred" });
    h3_trailler.text("Ver Trailer");

    var iframe_trailler = $("<iframe>");
    div_trailler.append(iframe_trailler);
    iframe_trailler.css("width", "100%");
    iframe_trailler.attr("height", "510");
    iframe_trailler.attr("src", result.trailer);

    return div_trailler;
}
