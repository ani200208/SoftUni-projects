function storeProvision(currentStock, delivery) {
    let stock = {};

    
    function addToStock(product, quantity) {
        if (stock.hasOwnProperty(product)) {
            stock[product] += Number(quantity);
        } else {
            stock[product] = Number(quantity);
        }
    }

    
    for (let i = 0; i < currentStock.length; i += 2) {
        let product = currentStock[i];
        let quantity = currentStock[i + 1];
        addToStock(product, quantity);
    }

    
    for (let i = 0; i < delivery.length; i += 2) {
        let product = delivery[i];
        let quantity = delivery[i + 1];
        addToStock(product, quantity);
    }

    
    for (let [product, quantity] of Object.entries(stock)) {
        console.log(`${product} -> ${quantity}`);
    }
}


let example1CurrentStock = [
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
];

let example1Delivery = [
    'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
];

let example2CurrentStock = [
    'Salt', '2', 'Fanta', '4', 'Apple', '14', 'Water', '4', 'Juice', '5'
];

let example2Delivery = [
    'Sugar', '44', 'Oil', '12', 'Apple', '7', 'Tomatoes', '7', 'Bananas', '30'
];

storeProvision(example1CurrentStock, example1Delivery);
storeProvision(example2CurrentStock, example2Delivery);
