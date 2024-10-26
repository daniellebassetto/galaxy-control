const patosContainer = document.getElementById('patos-container');
const loadingBar = document.getElementById('loading-bar');
const positions = new Set();

function mostrarLoading() {
    loadingBar.style.display = 'block';
    setTimeout(() => {
        loadingBar.style.display = 'none';
        iniciarMonitoramento();
    }, 3000);
}

function iniciarMonitoramento() {
    setInterval(criarPato, 3000);
}

function criarPato() {
    const patoDiv = document.createElement('div');
    patoDiv.classList.add('pato-container');

    const distancia = (Math.random() * 100).toFixed(2); // Distância em km
    const isXenofago = Math.random() < 0.5;
    const emBando = Math.random() < 0.5;

    let position;
    do {
        position = {
            left: Math.random() * 90 + 'vw',
            top: Math.random() * 70 + 'vh'
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
        <p class="pato-info">Distância: ${distancia} km</p>
    `;

    patosContainer.appendChild(patoDiv);
}

$(document).ready(function () {
    mostrarLoading();
});