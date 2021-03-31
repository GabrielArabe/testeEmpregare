// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function carregarVagas() {
    let endpoint = 'https://localhost:44304/api/Vaga';
    $.ajax({
        url: endpoint,
        method: 'GET',
        success: function (result) {
            console.log(result);
            result.forEach(function (r) {
                var salario = r.salario.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });
                $('#containerVagas').append(`<div class="col-md-3 col-sm-6"><h4>${r.cargo}</h4><p>${r.local}</p><p>${salario}</p></div>`)
            })
            
        }
    })
}

function cadastrarCandidato() {
    let endpoint = 'https://localhost:44304/api/Candidato';    
    let candidato = { nome: $('#nome').val(), telefone: $('#telefone').val(), email: $('#email').val(), senha: $('#senha').val()};
    $.ajax({
        url: endpoint,
        method: 'Post',
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(candidato),
        success: function (result) {
            if (result.success) {
                alert("inserido com sucesso");
                window.location.href = "https://localhost:44304/";
            }
            else {
                alert(result.message);
            }    

        }
    })
}

function logarCandidato() {
    let endpoint = 'https://localhost:44304/api/Login';
    let candidato = { email: $('#email').val(), senha: $('#senha').val() };
    $.ajax({
        url: endpoint,
        method: 'Post',
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(candidato),
        success: function (result) {
            if (result.success) {
                alert("Login efetuado com sucesso");
                window.location.href = "https://localhost:44304/";
            }
            else {
                alert(result.message);
            }

        }
    })
}

