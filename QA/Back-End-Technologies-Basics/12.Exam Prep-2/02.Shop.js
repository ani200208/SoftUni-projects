function shop(products) {
    
    const numProducts = parseInt(products[0]);
    const productsList = products.slice(1, numProducts + 1);
    const commands = products.slice(numProducts + 1);
  
   
    for (const command of commands) {
      if (command === "End") {
        break;
      } else if (command.startsWith("Sell")) {
        const soldProduct = productsList.shift();
        console.log(`${soldProduct} product sold!`);
      } else if (command.startsWith("Add")) {
        const newProduct = command.split(" ")[1];
        productsList.push(newProduct);
      } else if (command.startsWith("Swap")) {
        try {
          const [startIndex, endIndex] = command
            .split(" ")
            .slice(1)
            .map(Number);
          if (
            startIndex >= 0 &&
            startIndex < productsList.length &&
            endIndex >= 0 &&
            endIndex < productsList.length
          ) {
            [productsList[startIndex], productsList[endIndex]] = [
              productsList[endIndex],
              productsList[startIndex],
            ];
            console.log("Swapped!");
          }
        } catch (error) {
          
        }
      }
    }
  
   
    if (productsList.length) {
      console.log(`Products left: ${productsList.join(", ")}`);
    } else {
      console.log("The shop is empty");
    }
  }
  
  
  shop(["3", "Apple", "Banana", "Orange", "Sell", "End", "Swap 0 1"]);
  shop(["5", "Milk", "Eggs", "Bread", "Cheese", "Butter", "Add Yogurt", "Swap 1 4", "End"]);
  shop(["3", "Shampoo", "Soap", "Toothpaste", "Sell", "Sell", "Sell", "End"]);
  