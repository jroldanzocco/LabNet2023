let $boton = document.getElementById("enviar-numero");
let $ingresoNumero = document.getElementById("ingreso-numero");

const numeroSecreto = getRandomNumber();
let vidas;
let puntaje = 5;
let highscore = 0;

function ReiniciarJuego() {
  puntaje = 0;
  vidas = 3;
}
console.log(numeroSecreto);
ReiniciarJuego();
$boton.addEventListener("click", function () {
  if ($ingresoNumero.value == numeroSecreto) {
    puntaje++;
  } else {
    vidas--;
  }
  console.log("vidas: " + vidas);
  console.log("Puntaje: " + puntaje);
});

function getRandomNumber() {
  return Math.floor(Math.random() * 20 + 1);
}

$ingresoNumero.addEventListener("input", function () {
  this.value = this.value.replace(/[eE]/g, "");
  if (this.value < 1) {
    this.value = "";
  } else if (this.value > 20) {
    this.value = parseInt(this.value / 10);
  }
});
