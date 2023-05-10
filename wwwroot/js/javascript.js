const genre_ul = document.querySelector('.filter-genre-ul');
const genre_arrow = document.querySelector('.list-genre-arrow');
const price_form = document.querySelector('.filter-price-form');
const price_arrow = document.querySelector('.filter-price-arrow');
const type_list = document.querySelector('.filter-type-list');
const type_arrow = document.querySelector('.list-type-arrow');
const platform_list = document.querySelector('.filter-platform-ul');
const platform_arrow = document.querySelector('.list-platform-arrow');
const system_list = document.querySelector('.filter-system-ul');
const system_arrow = document.querySelector('.list-system-arrow');
const developer_list = document.querySelector('.filter-developer-ul');
const developer_arrow = document.querySelector('.list-developer-arrow');
const publisher_list = document.querySelector('.filter-publisher-ul');
const publisher_arrow = document.querySelector('.list-publisher-arrow');
const sort_price_arrow = document.querySelector('.sort-by-price-arrow');

let isClosed_list_genre = true;
let isClosed_form_price = true;
let isClosed_list_type = true;
let isClosed_list_platform = true;
let isClosed_list_system = true;
let isClosed_list_developer = true;
let isClosed_list_publisher = true;
let isSortDesc = true;

let game_type_copy_list = document.querySelectorAll('.choose-type-copy');
let game_type_copy_arrow = document.querySelectorAll('.list-game-type-arrow');
const game_type_copy_button = document.querySelectorAll('.game-type-copy-button');
const game_digital_select = document.querySelectorAll('.game-platform');
const game_physical_select = document.querySelectorAll('.game-system');
const img_basket_counter = document.querySelector('.nav-basket-counter');
const game_prices = document.querySelectorAll('.game-price span');


const min_price = document.querySelector(".filter-min-price");
const max_price = document.querySelector(".filter-max-price");

let allReleaseDates = document.querySelectorAll('.release-date');
let allDescriptions = document.querySelectorAll('.description');
let allGameNames = document.querySelectorAll('.game-name-title');
let allGameCovers = document.querySelectorAll('.game-cover');
let allGenresByGame = document.querySelectorAll(`.genre`);
let allDevelopersByGame = document.querySelectorAll(`.developer`);
let allPublishersByGame = document.querySelectorAll(`.publisher`);
const allGames = document.querySelectorAll('.btn-details');

let platform_game_in_basket;
let system_game_in_basket;

let isClosed_list_games_type_copy = [];

let list_games_in_basket = [];
let game_and_plsy = []; // 3 values
let game_plsy_local = []; // 4 values

let amount_games_in_basket;

let temp;
let firstIndex;
let lastIndex;

let Game = {};

if (localStorage.getItem('game-in-basket') !== null) { 
	list_games_in_basket.push(localStorage.getItem('game-in-basket'));
	}
display_number_games_in_basket();
function display_number_games_in_basket() {
	if (localStorage.getItem('game-in-basket') !== null && localStorage.getItem('game-in-basket').match(/\{/g) !== null) { 
	amount_games_in_basket = (localStorage.getItem('game-in-basket').match(/\{/g).length);
	if (amount_games_in_basket > 9) {
		img_basket_counter.textContent = '9+';
	}
	else {
		img_basket_counter.textContent = amount_games_in_basket;
	}
		img_basket_counter.style.display = 'flex';
	}
}

for(let i = 0; i < game_type_copy_list.length; i++) {
	isClosed_list_games_type_copy[i] = true;
}

function oc_form_price() {
    if(isClosed_form_price === true) {
        price_form.style.display = 'flex';
        isClosed_form_price = false;
        price_arrow.textContent = '▲';
    }
    else if (isClosed_form_price === false) {
        price_form.style.display = 'none';
        isClosed_form_price = true;
        price_arrow.textContent = '▼';
    }
}

const sort_value_button = document.querySelector(".input-for-sort");
function sort_price_change_arrow() {
    if(isSortDesc === true) {
        sort_price_arrow.textContent = '▲';
        isSortDesc = false;
    }
    else if (isSortDesc === false) {
        sort_price_arrow.textContent = '▼';
        isSortDesc = true;
    }
    sort_value_button.value = sort_price_arrow.textContent;
}

function oc_game_type_list(index) {
	
	for (let i = 0; i < isClosed_list_games_type_copy.length; i++) {
		if (i === parseInt(index) && isClosed_list_games_type_copy[index] === true) {
	        game_type_copy_list[i].style.display = 'block';
	        game_type_copy_arrow[i].textContent = "▲";
	        isClosed_list_games_type_copy[i] = false;
    	}
    	else if (i === parseInt(index) && isClosed_list_games_type_copy[index] === false) {
	        game_type_copy_list[i].style.display = 'none';
	        game_type_copy_arrow[i].textContent = "▼";
	        isClosed_list_games_type_copy[i] = true;
    	}
    	else {
			game_type_copy_list[i].style.display = 'none';
	    	game_type_copy_arrow[i].textContent = "▼";
	    	isClosed_list_games_type_copy[i] = true;
		}
	}
}

function change_main_type_button_to_digital(index) {
	game_type_copy_button[index].innerHTML = '<i class="chosen-type-copy-digital-img"></i></i><span class = "list-game-type-arrow">▼</span>';
	game_type_copy_button[index].value = 'digital';
	game_type_copy_arrow = document.querySelectorAll('.list-game-type-arrow');
	game_digital_select[index].style.display = 'block';
	game_physical_select[index].style.display = 'none';
    oc_game_type_list(index);
}

function change_main_type_button_to_physical(index) {
    game_type_copy_button[index].innerHTML = '<i class="chosen-type-copy-physical-img"></i></i><span class = "list-game-type-arrow">▼</span>';
    game_type_copy_button[index].value = 'physical';
    game_type_copy_arrow = document.querySelectorAll('.list-game-type-arrow');
    game_physical_select[index].style.display = 'block';
    game_digital_select[index].style.display = 'none';
    oc_game_type_list(index);
}

function pass_game_to_basket(Id, Name, Edition, Genres, Developer, Publisher, Date_release, index) {
	let Description = allDescriptions[index].innerHTML;
	Game = {
		id: Id,
		name: Name,
		edition: Edition,
		genres: Genres,
		developer: Developer,
		publisher: Publisher,
		date_release: Date_release,
		description: Description,
		price: parseInt(game_prices[index].textContent)
	}
	platform_game_in_basket = document.getElementById('game-platform-select-' + index);
	system_game_in_basket = document.getElementById('game-system-select-' + index);

	game_and_plsy = ['digital', platform_game_in_basket.value, JSON.stringify(Game)];
	list_games_in_basket.push(game_and_plsy);
	console.log(list_games_in_basket);
	localStorage.setItem('game-in-basket', list_games_in_basket);
	if (localStorage.getItem('game-in-basket')[0] === ",") {
		localStorage.setItem('game-in-basket', localStorage.getItem('game-in-basket').substring(1));
	}
	img_basket_counter.style.display = 'flex';
	display_number_games_in_basket();

	firstIndex = localStorage.getItem('game-in-basket').indexOf('{');
	lastIndex = localStorage.getItem('game-in-basket').indexOf('}') + 1;
	temp = localStorage.getItem('game-in-basket').substring(firstIndex, lastIndex);	
}

min_price.addEventListener("input", function() {
	if(parseInt(min_price.value) < 0) {
		min_price.value = 0;
	}
	if (parseInt(min_price.value) > parseInt(max_price.value)) {
		min_price.value = max_price.value;
	}
})
max_price.addEventListener("input", function() {
	if(parseInt(max_price.value) < 0) {
		max_price.value = 0;
	}
	if (parseInt(min_price.value) > parseInt(max_price.value)) {
		max_price.value = min_price.value;
	}
})

// popover for game details
for (var i = 0; i < allGames.length; i++) {
	let content = `<div class='content-popover-img'><img class="game-cover" src="${allGameCovers[i].src}" alt="${allGameCovers[i].alt}'"/></div><div>
	<span> Жанр: </span>
	<span>${allGenresByGame[i].innerHTML}</span>
	<br>
	<span>Дата виходу: ${allReleaseDates[i] != null ? allReleaseDates[i].innerHTML : 'колись'}</span><br>
	<span>Розробник:</span>
	<span>${allDevelopersByGame[i].innerHTML}</span>
	<br>
	<span>Видавець:</span>
	<span>${allPublishersByGame[i].innerHTML != "" ? allPublishersByGame[i].innerHTML : allDevelopersByGame[i].innerHTML}</span>
	<hr>
	<span>${allDescriptions[i].innerHTML}</span>`

	allGames[i].setAttribute("data-toggle", "popover");
	allGames[i].setAttribute("data-content", content);
	allGames[i].setAttribute('data-title', allGameNames[i].innerHTML);
}
$(document).ready(function () {
	
	$('[data-toggle="popover"').popover({
		container: 'body',
		placement: 'bottom',
		trigger: 'click',
		html: true,
	});
})
