//Pagina Inicial 
function geraFilmeParaLista(item) {

    var holder = $("<div>"); // faz o mesmo que var holder = document.createElement("div");
    holder.addClass("seg");

    var texto = $("<div>");
    texto.addClass("texto");

    var h2 = $("<h2>");
    h2.click(function () { loadFilmDetails(idTemp); });
    h2.text(item.titulo);
    h2.css({ cursor: "pointer" });
    texto.append(h2);
    holder.append(texto);

    var img = $("<img>");
    let idTemp = item.id;
    img.click(function () { loadFilmDetails(idTemp); });
    img.attr("src", "Imagens/" + item.id + item.imagem); //Adiciona  a Imagem do Filme
    img.css({ cursor: "pointer", width: "100%", minHeight: "100%", height: "auto", marginTop: "-65px" }); //css da imagens do filme
    holder.append(img);
    return holder;

}
//Gera uma lista de Filmes
function generateListFilmes(items) {
    var holder = $("<div>");
    holder.addClass("prim");
    var i;
    for (i = 0; i < items.length; i++) {
        holder.append(geraFilmeParaLista(items[i]));
    }
    $("#main").html("").append(holder);
}

//obtem lista de Filmes
function getFilmesList() {
    return fetch("/api/filmes", { headers: { Accept: "application/json" } })
        .then(function (resposta) {
            if (resposta.status === 200) {
                return resposta.json();
            } else {
                return Promise.reject(new Error("Um Erro ocurreu"));
            }
        });
}

//Gera uma Lista de detalhes dos filmes 
function getFilmDetails(idFilme) {
    return fetch("/api/filme/" + idFilme, { headers: { Accept: "application/json" } })
        .then(function (resposta) {
            if (resposta.status === 200) {
                return resposta.json();
            } else {
                return Promise.reject(new Error("Um Erro ocurreu"));
            }
        });
}

//Gera uma Lista de detalhes dos filmes 
function getRealizadorDetails(idRealizador) {
    return fetch("/api/realizador/" + idRealizador, { headers: { Accept: "application/json" } })
        .then(function (resposta) {
            if (resposta.status === 200) {
                return resposta.json();
            } else {
                return Promise.reject(new Error("Um Erro ocurreu"));
            }
        });
}
