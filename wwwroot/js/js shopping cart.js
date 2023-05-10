let infoGame = [];

let total_price = document.querySelector('.total-price-price');
const img_basket_counter = document.querySelector('.nav-basket-counter');
const div_list_games = document.querySelector('.shopping-cart-list-games');
const buy_button = document.querySelector('.shopping-cart-buy-button button');
let list_games_in_basket = [];

let amount_games_in_basket;
let cart_game = localStorage.getItem('game-in-basket');
let firstIndex = 0;
let lastIndex = 0;
let row_game = [];
let column_game = [];
let type_copy;
let platform_system;
let Game = {};
let amount_game;
let isScriptAppended = false;

let isExist = false;
if (localStorage.getItem('game-in-basket') !== null) { 
	list_games_in_basket.push(localStorage.getItem('game-in-basket'));
}
display_number_games_in_basket();

if (cart_game !== null) {
	parseGame();
	createTable_games();
}
disable_button_ifEmpty();

const game_id = document.querySelectorAll('.table-id-game');

function disable_button_ifEmpty() {
	if (row_game.length !== 0) {
		buy_button.disabled = false;
		buy_button.style.cursor = 'pointer';
	}
	else {
		buy_button.style.cursor = 'not-allowed';
		buy_button.style.background = '#7FAF7F';
		buy_button.disabled = true;
	}
}

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
	} else {
		img_basket_counter.style.display = 'none';
	}
}


function parseGame() {
	row_game = [];
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

function createTable_games() {
	let table_content_games = document.createElement('table');
	let table_content = '';
	let script_content_games;
	let script_content = [];
	for(let i in row_game) {
		table_content += '<tr class = "table-row-content"><td class = "table-id-game" style = "display:none">' + row_game[i][2].id + '</td><td class = "table-column table-header-1 table-content">' + row_game[i][2].name + 
			'<td class = "table-column table-header-2 table-content">' + row_game[i][1] + 
			'</td><td class = "table-column table-header-3 table-content table-game-price-' + i + '">' + row_game[i][2].price + '₴' + '</td>' + 
			'<td class = "table-column table-header-4 table-content table-amount-game-' + i + '"><input type="number" value = "' + row_game[i][3] + '" min="1" max="10" required>шт.</td>' + 
			'<td class = "table-column table-header-5 table-content table-total-price-' + i + '">' + row_game[i][2].price + '₴' + '</td>' + 
			'<td class = "table-column table-header-6 table-content table-remove-game-' + i + '"><button>Видалити</button></td></tr>';

		if (isScriptAppended) {
			script_content.push('price_game_' + i + ' = document.querySelector(".table-game-price-' + i + '");\n' + 
			'total_price_game_' + i + ' = document.querySelector(".table-total-price-' + i + '");\n' + 
			'total_price_' + i + ' = document.querySelector(".total-price-price");\n' + 
			'remove_button_' + i + ' = document.querySelector(".table-remove-game-' + i + '");\n' +
			'amount_game_field_' + i + '= document.querySelector(".table-amount-game-' + i + ' input");\n' + 
			'total_price_game_' + i + '.textContent = parseInt(price_game_' + i + '.textContent) * amount_game_field_' + i + '.value + "₴";\n' +
			'prev_total_price_game_' + i + ' = parseInt(total_price_game_' + i + '.textContent);\n' +
			'if(' + i + ' !== 0) {total_price_' + i + '.textContent = parseInt(total_price_' + i + '.textContent) + parseInt(total_price_game_' + i + '.textContent) + "₴";}\n' +
			'else {total_price_' + i + '.textContent = parseInt(total_price_game_' + i + '.textContent) + "₴";}\n' +
			'amount_game_field_' + i + '.addEventListener("input", function() {\n' + 
			'if(amount_game_field_' + i + '.validity.rangeOverflow) {\n' + 
			'amount_game_field_' + i + '.value = 10} else if (amount_game_field_' + i + '.validity.rangeUnderflow) {\n' + 
			'amount_game_field_' + i + '.value = 1;}\n' + 
			'else if(!amount_game_field_' + i + '.validity.valid){\n' + 
			'amount_game_field_' + i + '.value= 1;}\n' + 
			'total_price_game_' + i + '.textContent = parseInt(price_game_' + i + '.textContent) * amount_game_field_' + i + '.value + "₴";\n' + 
			'total_price_' + i + '.textContent = parseInt(total_price_' + i + '.textContent) - prev_total_price_game_' + i + ' + parseInt(total_price_game_' + i + '.textContent) + "₴";\n' + 
			'prev_total_price_game_' + i + ' = parseInt(total_price_game_' + i + '.textContent);\n' +
			'change_amount_game(' + i + ', amount_game_field_' + i + '.value);});\n\n' +
			'remove_button_' + i + '.addEventListener("click", function() { ' +
			'remove_game_cart(' + i + ');});'
			);
		} else {
			script_content.push('let price_game_' + i + ' = document.querySelector(".table-game-price-' + i + '");\n' + 
			'let total_price_game_' + i + ' = document.querySelector(".table-total-price-' + i + '");\n' + 
			'let total_price_' + i + ' = document.querySelector(".total-price-price");\n' + 
			'let remove_button_' + i + ' = document.querySelector(".table-remove-game-' + i + '");\n' +
			'let amount_game_field_' + i + '= document.querySelector(".table-amount-game-' + i + ' input");\n' + 
			'total_price_game_' + i + '.textContent = parseInt(price_game_' + i + '.textContent) * amount_game_field_' + i + '.value + "₴";\n' +
			'let prev_total_price_game_' + i + ' = parseInt(total_price_game_' + i + '.textContent);\n' +
			'if(' + i + ' !== 0) {total_price_' + i + '.textContent = parseInt(total_price_' + i + '.textContent) + parseInt(total_price_game_' + i + '.textContent) + "₴";}\n' +
			'else {total_price_' + i + '.textContent = parseInt(total_price_game_' + i + '.textContent) + "₴";}\n' +
			'amount_game_field_' + i + '.addEventListener("input", function() {\n' + 
			'if(amount_game_field_' + i + '.validity.rangeOverflow) {\n' + 
			'amount_game_field_' + i + '.value = 10} else if (amount_game_field_' + i + '.validity.rangeUnderflow) {\n' + 
			'amount_game_field_' + i + '.value = 1;}\n' + 
			'else if(!amount_game_field_' + i + '.validity.valid){\n' + 
			'amount_game_field_' + i + '.value= 1;}\n' + 
			'total_price_game_' + i + '.textContent = parseInt(price_game_' + i + '.textContent) * amount_game_field_' + i + '.value + "₴";\n' + 
			'total_price_' + i + '.textContent = parseInt(total_price_' + i + '.textContent) - prev_total_price_game_' + i + ' + parseInt(total_price_game_' + i + '.textContent) + "₴";\n' + 
			'prev_total_price_game_' + i + ' = parseInt(total_price_game_' + i + '.textContent);' +
			'change_amount_game(' + i + ', amount_game_field_' + i + '.value);});\n\n' +
			'remove_button_' + i + '.addEventListener("click", function() { ' +
			'remove_game_cart(' + i + ');});'
			);
			isScriptAppended = true;
		}
			
	}
	
	table_content_games.classList.add('shopping-cart-table-content');
	table_content_games.innerHTML = table_content;
	div_list_games.appendChild(table_content_games);
	
	if (row_game.length !== 0) {
		const tr_content = document.querySelectorAll('.table-row-content');
		let parent_tr = tr_content[0].parentNode;
		let row_index = 0;
		for (let i = 0; i < row_game.length; i++) {
			script_content_games = document.createElement('script');
			script_content_games.textContent = script_content[i];
			script_content_games.defer = true;
			row_index = i + 1;
			if (row_index !== row_game.length) {
				parent_tr.insertBefore(script_content_games, tr_content[i]);
			} else {
				parent_tr.insertBefore(script_content_games, tr_content[i].nextSibling);
			}
		}
	}

}
let temp;
let platform_system_game = document.querySelectorAll('.table-header-2.table-content');
let id_game = document.querySelectorAll('.table-id-game');
let total_price_game = document.querySelectorAll('.table-header-5.table-content');
let price_game = document.querySelectorAll('.table-header-3.table-content');
let amount_game_tag = document.querySelectorAll('.table-header-4.table-content input');

function remove_game_cart(index) {		
		list_games_in_basket = [];
		temp = row_game;
		row_game = [];
		for (let i in temp) {
			type_copy = 'digital';
			if (temp[i][2].id === id_game[index].textContent) {
				if (temp[i][1] === platform_system_game[index].textContent) {
					if (temp[i][0] === type_copy) {
						continue;
					}
				}
			}
			column_game = [temp[i][0], temp[i][1], JSON.stringify(temp[i][2]), temp[i][3]];
			row_game.push(column_game);

			for (let ix = 0; ix < temp[i][3]; ix++) {
				list_games_in_basket.push([temp[i][0], temp[i][1], JSON.stringify(temp[i][2])]);
			}
			
		}
		localStorage.setItem('game-in-basket', list_games_in_basket);
		display_number_games_in_basket();
		total_price.textContent = parseInt(total_price.textContent) - parseInt(total_price_game[index].textContent) + '₴';

		let scripts = document.getElementsByTagName('script');
		for (let i = scripts.length; i >= 0; i--) {
			if (scripts[i]) {
				scripts[i].parentNode.removeChild(scripts[i]);
			}
		}
		document.querySelector('.shopping-cart-table-content').remove();

		for(let i in row_game) {
			
			row_game[i][2] = JSON.parse(row_game[i][2]);
		}
		
		createTable_games();
		disable_button_ifEmpty();
		total_price_game = document.querySelectorAll('.table-header-5.table-content');
		price_game = document.querySelectorAll('.table-header-3.table-content');
		amount_game_tag = document.querySelectorAll('.table-header-4.table-content input');
		for (let i in row_game) {
			total_price_game[i].textContent = parseInt(price_game[i].textContent) * amount_game_tag[i].value + '₴';
		}
		id_game = document.querySelectorAll('.table-id-game');
		platform_system_game = document.querySelectorAll('.table-header-2.table-content');
}

function change_amount_game(index, amount) {
	list_games_in_basket = [];
	for (let i in row_game) {
		type_copy = 'digital';
		if (row_game[i][2].id === id_game[index].textContent) {
			if (row_game[i][1] === platform_system_game[index].textContent) {
				if (row_game[i][0] === type_copy) {
					row_game[i][3] = parseInt(amount);
				}
			}
		}
		for (let ix = 0; ix < row_game[i][3]; ix++) {
			list_games_in_basket.push([row_game[i][0], row_game[i][1], JSON.stringify(row_game[i][2])]);
		}
	}
	localStorage.setItem('game-in-basket', list_games_in_basket);
	display_number_games_in_basket();
}

buy_button.addEventListener('click', function () {
	localStorage.setItem('total-price', parseInt(total_price.textContent));
	for (let i in row_game) {
		infoGame.push(row_game[i][0]);
	}
	$.ajax({
		url: "/Basket/Checkout",
		type: 'GET',
		dataType: "text",
		data: JSON.stringify(infoGame),
		success: function(data) {
			window.location.href = "/" + data;
		},
		error: function(status,er) {
			alert(status + '.\n' + er);
		}
	});
	
	
});