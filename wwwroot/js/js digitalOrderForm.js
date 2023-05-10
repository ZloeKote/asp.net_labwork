const img_basket_counter = document.querySelector('.nav-basket-counter');
let amount_games_in_basket;
let firstIndex = 0;
let lastIndex = 0;
let cart_game = localStorage.getItem('game-in-basket');
let isExist = false;
let row_game = [];
let column_game = [];
let type_copy;
let platform_system;
let Game = new Object();
let amount_game;
let id_city;

let full_form = new Object();
let infoGame = [];
let infoGames = [];

parseGame();

const final_price = document.querySelector('.general-price .price');
final_price.textContent = localStorage.getItem('total-price') + '₴';
display_number_games_in_basket();

const user_name = document.querySelector('.form-name input');
const user_surname = document.querySelector('.form-surname input');
const user_email = document.querySelector('.form-email input');
const confirm_order_button = document.querySelector('.order-form-total-wrapper .buy-button');
const footer = document.querySelector('.footer');



const div_prices = document.querySelector('.split-prices');
for (var i = 0; i < row_game.length; i++) {
	let ListOfItems = document.createElement('span');
	ListOfItems.classList.add("item-info");
	ListOfItems.textContent += `${row_game[i][3]}x ${row_game[i][2].name} (${row_game[i][1]}) = ${row_game[i][3]}x${row_game[i][2].price}₴ (${row_game[i][3]*row_game[i][2].price}₴)`;
	div_prices.appendChild(ListOfItems);
}


user_name.addEventListener('input', function() {
	if (!user_name.validity.valid) {
		user_name.style.transition = '1s';
		user_name.style.border = '2px dashed red';
	} else {
		user_name.style.border = '2px solid lightgreen';
	}
});
user_surname.addEventListener('input', function() {
	if (!user_surname.validity.valid) {
		user_surname.style.transition = '1s';
		user_surname.style.border = '2px dashed red';
	} else {
		user_surname.style.border = '2px solid lightgreen';
	}
});
user_email.addEventListener('input', function() {
	if (!user_email.validity.valid) {
		user_email.style.transition = '1s';
		user_email.style.border = '2px dashed red';
	} else {
		user_email.style.border = '2px solid lightgreen';
	}
});

function display_number_games_in_basket() {
	if (localStorage.getItem('game-in-basket')) { 
	amount_games_in_basket = (localStorage.getItem('game-in-basket').match(/{/g).length);
	if (amount_games_in_basket > 9) {
		img_basket_counter.textContent = '9+';
	}
	else {
		img_basket_counter.textContent = amount_games_in_basket;
	}
		img_basket_counter.style.display = 'flex';
	}
}

let isValid = true;
function checkAll() {
	if (!user_name.validity.valid) {
		user_name.style.border = '2px solid #605F5F';
		user_name.style.transition = '0.5s';
		setTimeout('user_name.style.border = "2px dashed red"', 300);
		isValid = false;
	}
	if (!user_surname.validity.valid) {
		user_surname.style.border = '2px solid #605F5F';
		user_surname.style.transition = '0.5s';
		setTimeout('user_surname.style.border = "2px dashed red"', 300);
		isValid = false;
	}
	if (!user_email.validity.valid) {
		user_email.style.border = '2px solid #605F5F';
		user_email.style.transition = '0.5s';
		setTimeout('user_email.style.border = "2px dashed red"', 300);
		isValid = false;
	}
}

function parseGame() {
	firstIndex = 0;
	lastIndex = cart_game.indexOf(',');
	while(lastIndex !== -1) {
		isExist = false;
		
		type_copy = cart_game.substring(firstIndex, lastIndex);

		firstIndex = lastIndex + 1;
		lastIndex = cart_game.indexOf(',', firstIndex);
		platform_system = cart_game.substring(firstIndex, lastIndex);

		firstIndex = lastIndex + 1;
		lastIndex = cart_game.indexOf('}', firstIndex);
		Game = JSON.parse(cart_game.substring(firstIndex, lastIndex+1));
		
		firstIndex = lastIndex + 2;
		lastIndex = cart_game.indexOf(',', firstIndex);
		for (let i = 0; i < row_game.length; i++) {
			amount_game = row_game[i][3];
			if (JSON.stringify(row_game[i][2]) === JSON.stringify(Game)) {
				
				if (row_game[i][1] === platform_system) {
					if (row_game[i][0] === type_copy) {
						amount_game++;
						if (amount_game > 10) {
							amount_game = 10;
						}
						row_game[i][3] = amount_game;
						isExist = true;
						continue;
					}
				}
			}
		}
		if (!isExist) {
			amount_game = 1;
			column_game = [type_copy, platform_system, Game, amount_game];
			row_game.push(column_game);
		}
	}
	
}
let isExistError = false;
let isExistStyleError = false;
function showError(number) {
	number = parseInt(number);
	if (!isExistError) {
		if (!isExistError) {
		let popup_window = document.createElement('a');
		
		let popup_window_block = document.createElement('div');
		popup_window.id = "popup-window";
		popup_window.href = "#";
		popup_window_block.id = 'popup-window-block';
		switch(number) {
			case 21:
				popup_window_block.textContent = "Введено некоректні дані в поле Ім'я!";
				break;
			case 22:
				popup_window_block.textContent = "Введено некоректні дані в поле Прізвище!";
				break;
			case 24:
				popup_window_block.textContent = "Введено некоректні дані в поле Пошта!";
				break;
			case 20:
				popup_window_block.textContent = "Ти бачив ціну за доставку?? Краще нічого не придбай!";
				break;
			default:
				popup_window_block.textContent = "Что?";
		}
		
		if (!isExistStyleError) {
			let popup_style = document.createElement('style');
		popup_style.textContent = '#popup-window {' +
        'display: none;' +
        'position: absolute;' +
        'bottom: 50px;' +
        'left: 25px;' +
        'width: 350px;' +
        'height: 100px;' +
        'z-index: 1' +
      '}' +
      '#popup-window-block {' +
        'width: 350px;' +
        'height: 100px;' +
        'text-align: left;' +
        'padding-left: 15px; ' +
        'line-height: 100px;' +
        'border: 3px solid var(--border-color-order-form); ' +
        'color: var(--color-text-order-form);' +
        'font-size: 18px;' +
        'background-color: var(--background-color-order-form);' +
        'border-radius: 10px;' +
        'position: absolute;' +
        'top: 0;' +
        'right: 0;' +
        'bottom: 0;' +
        'left: 0;' +
        'margin: auto;' +
      '} ' +
      '#popup-window-block:hover {' +
      'transition: 0.5s;' +
	  'background-color: var(--border-color-order-form); }' +
      '#popup-window:target {display: block}';
      footer.parentNode.insertBefore(popup_style, footer);
      isExistStyleError = true;
	}
      footer.parentNode.insertBefore(popup_window, footer);
      popup_window.appendChild(popup_window_block);
      window.location.href = "#popup-window";
      
      isExistError = true;
	}      
	} else {
		$("#popup-window").remove();
		isExistError = false;
	}
}


let total_price_input = document.getElementById('total_price_input');
total_price_input.value = final_price.textContent;
function sendData(){
	isValid = true;
	checkAll();
	if (!isValid) {
		return;
	}
	for (let i in row_game) {
		infoGame.push(row_game[i][2].id, row_game[i][0], row_game[i][1], `${row_game[i][3]}`);
	}
	
	full_form = {
		name: user_name.value,
		surname: user_surname.value,
		email: user_email.value,
		games: infoGame,
		total_price: parseFloat(final_price.innerText)
	}
	console.log(JSON.stringify(full_form));
	console.log(full_form.name, " ", full_form.surname, " ", full_form.email, " ", full_form.games, " ", full_form.total_price);
	console.log(full_form.name, " ", full_form.surname, " ", typeof (full_form.email), " ", typeof (full_form.games), " ", typeof (full_form.total_price));
	console.log(typeof (full_form.games[0]) + " " + typeof (full_form.games[3]));
	$.ajax({
		url: "/Basket/Checkout",
		type: 'POST',
		dataType: 'json',
		data: JSON.stringify(full_form),
		contentType: 'application/json; charset=utf-8',
		mimeType: 'application/json',
		
		success: function(data, status) {
			if (parseInt(data) === 10) {
				localStorage.removeItem('game-in-basket');
				localStorage.removeItem('total-price');
				window.location.href = '/Games/List';
			} else if (parseInt(data) === 31) {
				window.location.href = "/Error/Failure31";
			} else if (parseInt(data) === 32) {
				window.location.href = "/Error/Failure32";
			}
			else {
				showError(parseInt(data));
			}
		},
		error: function(data, status, er) {
			alert(status + '. This is your data ' + data + '\n' + er);
		}
	});
}
confirm_order_button.addEventListener('click', function(e) {
	sendData();
	e.preventDefault();
});