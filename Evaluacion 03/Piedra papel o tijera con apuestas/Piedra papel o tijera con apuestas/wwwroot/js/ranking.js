
async function cargarRanking() {

    const tabla = document.getElementById("tablaRanking");
    const mensaje = document.getElementById("mensaje");

    try {
        const respuesta = await fetch("/api/ranking");

        if (!respuesta.ok) {
            throw new Error("No se pudo obtener el ranking.");
        }

        const jugadores = await respuesta.json();

        tabla.innerHTML = "";

        if (jugadores.length === 0) {
            mensaje.textContent = "Todavía no hay puntajes registrados.";
            return;
        }

        jugadores.forEach((jugador, indice) => {

            const fila = document.createElement("tr");

            if (indice === 0) {
                fila.classList.add("primero");
            }

            const posicion = document.createElement("td");
            const nombre = document.createElement("td");
            const puntos = document.createElement("td");

            posicion.textContent = indice + 1;
            nombre.textContent = jugador.jugador;
            puntos.textContent = jugador.puntos;

            fila.appendChild(posicion);
            fila.appendChild(nombre);
            fila.appendChild(puntos);

            tabla.appendChild(fila);
        });

        mensaje.textContent = "";

    } catch (error) {
        mensaje.textContent = "Error al cargar el ranking.";
    }
}

cargarRanking();
