const patosContainer = document.getElementById('patos-container');
const loadingBar = document.getElementById('loading-bar');
const loadingMessage = document.getElementById('loading-message');
const positions = new Set();

function mostrarLoading() {
    loadingBar.style.display = 'block';
    setTimeout(() => {
        loadingBar.style.display = 'none';
        loadingMessage.textContent = 'Óculos conectado';
        iniciarMonitoramento();
    }, 3000);
}

function iniciarMonitoramento() {
    criarPatoComIntervaloAleatorio();
}

function criarPatoComIntervaloAleatorio() {
    const intervaloAleatorio = Math.random() * (10000 - 5000) + 5000;
    setTimeout(() => {
        criarPato();
        criarPatoComIntervaloAleatorio();
    }, intervaloAleatorio);
}

function criarPato() {
    const patoDiv = document.createElement('div');
    patoDiv.classList.add('pato-container');

    const distancia = (Math.random() * 100).toFixed(2);
    const isXenofago = Math.random() < 0.5;
    const emBando = Math.random() < 0.5;

    const containerWidth = patosContainer.clientWidth;
    const containerHeight = patosContainer.clientHeight;

    let position;
    do {
        position = {
            left: Math.random() * (containerWidth - 150) + 'px',
            top: Math.random() * (containerHeight - 150) + 'px'
        };
    } while (positions.has(`${position.left}-${position.top}`));

    positions.add(`${position.left}-${position.top}`);

    patoDiv.style.left = position.left;
    patoDiv.style.top = position.top;

    const imgSrc = emBando
        ? isXenofago ? '/img/bando_pato_xenofago.png' : '/img/bando_pato_normal.png'
        : isXenofago ? '/img/pato_xenofago.png' : '/img/pato_normal.png';

    patoDiv.innerHTML = `
        <img src="${imgSrc}" alt="Pato" class="pato">
        <p class="pato-info">${distancia} parsecs</p>
    `;
   
    patoDiv.onclick = () => abrirModal(distancia, isXenofago, emBando);

    patosContainer.appendChild(patoDiv);

    const tempoRemocaoAleatorio = Math.random() * (20000 - 10000) + 10000;
    setTimeout(() => {
        patoDiv.remove();
        positions.delete(`${position.left}-${position.top}`);
    }, tempoRemocaoAleatorio);
}

function gerarEstrategia(distancia, emBando) {
    if (distancia < 20) {
        return emBando
            ? "Estratégia: Eles são mais rápidos juntos! Use uma rede de captura e prepare um local seguro para contenção!"
            : "Estratégia: Ative a armadilha instantânea! O pato não terá para onde fugir.";
    } else if (distancia < 50) {
        return emBando
            ? "Estratégia: Espalhe comida para distraí-los e ative a armadilha ao mesmo tempo!"
            : "Estratégia: Aproxime-se com cautela. Utilize um apito para atraí-lo e então lance a rede.";
    } else if (distancia < 75) {
        return emBando
            ? "Estratégia: Use um dispositivo de camuflagem para se misturar ao ambiente e esperar o momento certo para atacar!"
            : "Estratégia: Se aproxime de forma furtiva, um pouco de comida pode atrair o pato para uma emboscada.";
    } else {
        return emBando
            ? "Estratégia: Use um drone de monitoramento para observar o grupo e planejar um ataque quando se separarem!"
            : "Estratégia: Aguarde pacientemente, talvez ele venha até você se você deixar um pouco de comida para atraí-lo.";
    }
}

function abrirModal(distancia, isXenofago, emBando) {
    const modal = document.getElementById('patoModal');
    const tipoDePatoElement = document.getElementById('tipoDePato');
    const distanciaElement = document.getElementById('distancia');
    const estrategiaElement = document.getElementById('estrategia');

    tipoDePatoElement.textContent = isXenofago ? (emBando ? "VISHHH É UM BANDO DE XENÓFAGOS" : `VISHHH É UM XENÓFAGO`) : (emBando ? "UFAAA, SÃO SÓ PATOS COMUNS" : "UFAAA, É SÓ UM PATO COMUM");
    distanciaElement.textContent = `Distância: ${distancia} parsecs`;

    if (isXenofago) {
        estrategiaElement.textContent = gerarEstrategia(distancia, emBando);
    }

    modal.style.display = 'block';

    const closeButton = document.getElementsByClassName("close")[0];
    closeButton.onclick = () => {
        modal.style.display = 'none';
    };

    window.onclick = (event) => {
        if (event.target === modal) {
            modal.style.display = 'none';
        }
    };
}

document.addEventListener('DOMContentLoaded', function () {
    mostrarLoading();
});