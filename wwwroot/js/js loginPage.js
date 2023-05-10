const customer_button = document.querySelector(".log-in-button.customer");
const operator_button = document.querySelector(".log-in-button.operator");
const courier_button = document.querySelector(".log-in-button.courier");


if (localStorage.getItem("user-role") !== null) {
	window.location.href = "/games";
}

customer_button.addEventListener("click", function() {
	localStorage.setItem("user-role", "customer");
	window.location.href = "/games";
});

operator_button.addEventListener("click", function() {
	localStorage.setItem("user-role", "operator");
	window.location.href = "/games";
});

courier_button.addEventListener("click", function() {
	localStorage.setItem("user-role", "courier");
	window.location.href = "/games";
});