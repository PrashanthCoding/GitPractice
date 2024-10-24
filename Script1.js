const users = [
    { id: 1, name: "John" },
    { id: 2, name: "Jane" },
    { id: 3, name: "Bob" }
];

const names = users.map(user => user.name);
console.log(names);  // Output: ["John", "Jane", "Bob"]
