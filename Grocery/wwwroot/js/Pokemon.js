﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
// JAVASCRIPT CODE WILL GO HERE

// WHEN DOCUMENT READY
var apiUrl = "https://pokeapi.co/api/v2/pokemon/";
var input = document.querySelector(".pokemon-input");
var pokemonName = document.querySelector(".pokemon-name");
var pokemonImage = document.querySelector(".pokemon-image");

function getPokemonData() {
    axios.get(apiUrl + input.value + "/")
        .then(function (response) {
            pokemonName.innerHTML = response.data.forms[0].name;
            pokemonImage.src = response.data.sprites.front_default;
        })
        .catch(function (error) {
            pokemonName.innerHTML = "(An error has occurred.)";
            pokemonImage.src = "";
        });
}

var button = document.querySelector(".pokemon-button");
button.addEventListener("click", getPokemonData)