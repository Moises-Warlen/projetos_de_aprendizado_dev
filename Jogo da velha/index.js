// atribuindo  valor a jogador
var jogador = "X";
// essa função faz preenche as celulas
function jogar(celula) {
    if (celula.innerHTML == "") {
        celula.innerHTML = jogador;
        if (vencedor == "") {
            celula.innerHTML = jogador;
        }
        if (jogador == "X") {
            jogador = "O";
        } else {
            jogador = "X"
        }
        // pegando o id da div mostrador 
        var jogando = document.getElementById("mostrador");
        jogando.innerHTML = " Jogador " + jogador;
    }
    // pengando o id de cada celula da tabela
    var a1 = document.getElementById("a1").innerHTML;
    console.log(a1);
    var a2 = document.getElementById("a2").innerHTML;
    console.log(a2);
    var a3 = document.getElementById("a3").innerHTML;
    console.log(a3);
    var b1 = document.getElementById("b1").innerHTML;
    console.log(b1);
    var b2 = document.getElementById("b2").innerHTML;
    console.log(b2);
    var b3 = document.getElementById("b3").innerHTML;
    console.log(b3);
    var c1 = document.getElementById("c1").innerHTML;
    console.log(c1);
    var c2 = document.getElementById("c2").innerHTML;
    console.log(c2);
    var c3 = document.getElementById("c3").innerHTML;
    console.log(c3);
    var vencedor = "";
    // fazendo a validação de qual posição deu ganhador
    if ((a1 == b1 && a1 == c1 && a1 != "") || (a1 == a2 && a1 == a3 && a1 != "") || (a1 == b2 && a1 == c3 && a1 != "")) {
        vencedor = a1;
    }
    else if ((b2 == b1 && b2 == b3 && b2 != "") || (b2 == a2 && b2 == c2 && b2 != "") || (b2 == a3 && b2 == c1 && b2 != "")) {
        vencedor = b2;
    } else if (((c3 == c2 && c3 == c1) || (c3 == a3 && c3 == b3)) && c3 != "") {
        vencedor = c3;
    }
    // validando se houve empate
    if (a1 != "" && a2 != "" && a3 != "" && b1 != "" && b2 != "" && b3 != "" && c1 != "" && c2 != "" && 3 != "") {
        jogando.innerHTML = " Jogo Empatado ";
        jogador = null;
    }
    // finaliza o jogo e mostra resultado
    if (vencedor != "") {
        jogando.innerHTML = " Vencedor " + vencedor;
        jogador = null;
    }
}
//função que reinicia o game
function reiniciar() {
    window.location.reload();
}


