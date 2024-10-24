function elementExists(arr, element) {
    return arr.includes(element);
}

console.log(elementExists([1, 2, 3, 4], 3));  // Output: true
console.log(elementExists([1, 2, 3, 4], 5));  // Output: false
