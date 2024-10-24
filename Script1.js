const users = [
    { id: 1, name: "Prashanth" },
    { id: 2, name: "Anty" },
    { id: 3, name: "Red" }
];

const names = users.map(user => user.name);
console.log(names);  // Output: ["Prashanth", "Anty", "Red"]
