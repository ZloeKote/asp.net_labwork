const exit_button = document.querySelector(".nav-menu-item.exit");
const user_block = document.querySelector(".nav-menu-item.user-role");
const user_link = document.querySelector(".nav-menu-item.user-role a");
const img_basket_countera = document.querySelector('.nav-basket-counter');
let user_role = localStorage.getItem("user-role");

let amount_games_in_basket1;

display_number_games_in_basket();

exit_button.addEventListener("click", function() {
	localStorage.clear();
});

function display_number_games_in_basket() {
	if (localStorage.getItem('game-in-basket')) {
	amount_games_in_basket1 = (localStorage.getItem('game-in-basket').match(/{/g).length);
	if (amount_games_in_basket1 > 9) {
		img_basket_countera.textContent = '9+';
	}
	else {
		img_basket_countera.textContent = amount_games_in_basket1;
	}
		img_basket_countera.style.display = 'flex';
	} else {
		img_basket_countera.style.display = 'none';
	}
}