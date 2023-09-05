let $boton = document.getElementById("boton-enviar");

$boton.addEventListener("click", function (e) {
  e.preventDefault();
  console.log(getRandomNumber());
});

function getRandomNumber() {
  return Math.floor(Math.random() * 20 + 1);
}
