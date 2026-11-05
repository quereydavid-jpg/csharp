// @ts-nocheck
const idPartida = sessionStorage.getItem("idPartida");
const nombre = sessionStorage.getItem("nombreJugador");

let fichas = 100;
let jugadaElegida = "";

const botonJugar = document.getElementById("botonJugar");
const mensaje = document.getElementById("mensaje");

if (!idPartida || !nombre) {
    window.location.href = "index.html";
}

document.getElementById("nombreJugador").textContent = nombre;

function elegir(jugada) {
    jugadaElegida = jugada;

    document.querySelectorAll(".opcion").forEach(opcion => {
        opcion.classList.remove("seleccionada");
    });

    const boton = document.getElementById(jugada);

    if (boton) {
        boton.classList.add("seleccionada");
    }
}

async function jugarRonda() {
    mensaje.textContent = "";

    if (!jugadaElegida) {
        mensaje.textContent = "Primero elige piedra, papel o tijera.";
        return;
    }

    const entrada = document.getElementById("apuesta");
    const apuesta = Number(entrada.value);

    if (!Number.isInteger(apuesta) || apuesta < 1 || apuesta > fichas) {
        mensaje.textContent = "La apuesta debe estar entre 1 y " + fichas + ".";
        return;
    }

    botonJugar.disabled = true;

    try {
        const respuesta = await fetch("/api/juego/ronda", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                idPartida: idPartida,
                jugada: jugadaElegida,
                apuesta: apuesta
            })
        });

        if (!respuesta.ok) {
            mensaje.textContent = await respuesta.text();
            return;
        }

        const datos = await respuesta.json();

        // El saldo siempre lo calcula el servidor.
        fichas = datos.fichas;

        document.getElementById("fichas").textContent = fichas;
        entrada.max = fichas;

        document.getElementById("resultado").style.display = "block";

        document.getElementById("jugadaJugador").textContent =
            datos.jugadaJugador;

        document.getElementById("jugadaComputadora").textContent =
            datos.jugadaComputadora;

        let texto = "";

        if (datos.resultado === "Gana") {
            texto = "🎉 ¡Ganaste la ronda!";
        }
        else if (datos.resultado === "Pierde") {
            texto = "😢 Perdiste la ronda";
        }
        else {
            texto = "🤝 ¡Empate!";
        }

        document.getElementById("textoResultado").textContent = texto;

        document.getElementById("textoFichas").textContent =
            "Ahora tienes " + fichas + " fichas.";

        if (datos.terminado) {
            botonJugar.disabled = true;
            botonJugar.textContent = "Partida terminada";

            sessionStorage.removeItem("idPartida");

            if (fichas >= 500) {
                mensaje.textContent = "¡Felicidades! Llegaste a la meta.";
            }
            else {
                mensaje.textContent = "Te quedaste sin fichas.";
            }
        }

    } catch (error) {
        mensaje.textContent = "Error al conectar con el servidor.";
    } finally {
        if (sessionStorage.getItem("idPartida")) {
            botonJugar.disabled = false;
        }
    }
}