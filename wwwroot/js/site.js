$(document).ready(function () {
    getDataTable('#user-table')
    getDataTable('#nave-table')
});

$('.close-alert-sucess').click(function () {
    $('.alert').hide('hide');
});

$('.close-alert-error').click(function () {
    $('.alert').hide('hide');
});

function getDataTable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ at&eacute; _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 at&eacute; 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}

$(document).ready(function () {
    $("#showHidePassword").on('click', function () {
        var passwordField = $("#senha");
        var passwordFieldType = passwordField.attr('type');
        if (passwordFieldType === 'password') {
            passwordField.attr('type', 'text');
            $("#showHidePassword i").removeClass('fa-eye').addClass('fa-eye-slash');
        } else {
            passwordField.attr('type', 'password');
            $("#showHidePassword i").removeClass('fa-eye-slash').addClass('fa-eye');
        }
    });
});

function openClassificacaoModal() {
    if ($("#codigoRastreio").val() && $("#dataEncontro").val() && $("#tamanho").val() && $("#cor").val()
        && $("#tipoLocal").val() && $("#local").val() && $("#armamento").val() && $("#combustivel").val()
        && $("#tripulanteSaudavel").val() && $("#tripulanteFerido").val() && $("#tripulanteSemVida").val()
        && $("#grauAvaria").val() && $("#potencialTecnologico").val() && $("#grauPericulosidade").val()) {
        var formData = $("#naveForm").serialize();

        // Fazer uma requisição para carregar a PartialView de classificação
        $.ajax({
            url: '/Nave/ClassificarNave',
            method: 'POST',
            data: formData,
            success: function (data) {
                $("#classificacaoContent").html(data);
                $("#classificacaoModal").modal('show');
            }
        });
    } else {
        alert("Preencha todos os campos antes de escolher o uso futuro.");
    }
}

function selecionarClassificacao() {
    var classificacaoSelecionada = $("input[name='classificacao']:checked").val();

    if (classificacaoSelecionada) {
        $("#Classificacao").val(classificacaoSelecionada);
        $("#classificacaoModal").modal('hide');
        $("#btnSalvar").prop("disabled", false);
    } else {
        alert("Por favor, selecione uma classificação.");
    }
}