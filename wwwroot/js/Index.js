// Ensure this function is called after the DOM is fully loaded
document.addEventListener("DOMContentLoaded", function () {
    const products = @Html.Raw(Json.Serialize(ViewData["Products"]));

    products.forEach(product => {
        displayImage(product.Category, `productImage-${product.ProductID}`);
    });
});

function displayImage(category, imgElementId) {
    const imgElement = document.getElementById(imgElementId);
    let imgSrc = '';

    switch (category) {
        case 'Bowl':
            imgSrc = "~/Images/Bowl.png"; // Replace with the actual path to your image
            break;
        case 'Cup':
            imgSrc = 'C:/Lisha Naidoo POE/wwwroot/Images/Cup.png'; // Replace with the actual path to your image
            break;
        case 'Plate':
            imgSrc = '/Images/Plate.png'; // Replace with the actual path to your image
            break;
        case 'Pot':
            imgSrc = '/Images/Pot.png'; // Replace with the actual path to your image
            break;
        default:
            imgSrc = '/Images/Other.png'; // Optional default image
    }

    if (imgSrc) {
        imgElement.src = imgSrc;
        imgElement.style.display = 'block';
    } else {
        imgElement.style.display = 'none';
    }
}
