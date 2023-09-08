let $boton = document.getElementById("enviar-numero");
let $ingresoNumero = document.getElementById("ingreso-numero");
let $puntaje = document.getElementById("puntaje");
let $highscore = document.getElementById("highscore");
let $pista = document.getElementById("pista");
let $ronda = document.getElementById("ronda");

let numeroSecreto;
let puntaje;
let highscore = 0;
let ronda = 1;

iniciarJuego(ronda);

//Eventos
$boton.addEventListener("click", function () {
  if ($ingresoNumero.value == numeroSecreto) {
    puntaje += 3;
    ronda++;
    getHighscore(puntaje);
    victoria();
  } else if (
    $ingresoNumero.value != numeroSecreto &&
    $ingresoNumero.value != ""
  ) {
    puntaje--;
    pista();
  }

  if (puntaje == 0) {
    derrota();
  }
  $puntaje.innerText = puntaje;
});

$ingresoNumero.addEventListener("input", function () {
  this.value = this.value.replace(/[eE]/g, "");
  if (this.value < 1) {
    this.value = "";
  } else if (this.value > 20) {
    this.value = parseInt(this.value / 10);
  }
});

//Funciones
const getHighscore = (puntos) => {
  if (puntos > highscore) {
    highscore = puntos;
  }
  return highscore;
};

function victoria() {
  Swal.fire({
    icon: "success",
    title: "Ganaste",
    text: `Bien ahi! Adivinaste el numero secreto. Era ${numeroSecreto}`,
  });
  iniciarJuego(ronda);
}
function derrota() {
  Swal.fire({
    icon: "error",
    title: "Perdiste",
    text: `Mala suerte! El numero secreto era ${numeroSecreto}`,
  });
  ronda = 1;
  iniciarJuego(ronda);
}

function iniciarJuego(ronda) {
  $pista.innerText = "Adivina el número entre 1 y 20";
  $ingresoNumero.value = "";
  reiniciarNumero();
  if (ronda == 1) {
    puntaje = 20;
  }
  $ronda.innerText = `Ronda: ${ronda}`;
  $puntaje.innerText = puntaje;
  $highscore.innerText = highscore;
}

function getRandomNumber() {
  return Math.floor(Math.random() * 20 + 1);
}

function reiniciarNumero() {
  numeroSecreto = getRandomNumber();
}

function pista() {
  if ($ingresoNumero.value < numeroSecreto) {
    $pista.innerText = "Muy bajo!";
  } else if ($ingresoNumero.value > numeroSecreto) {
    $pista.innerText = "Muy alto!";
  }
}
