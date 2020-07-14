const uri = 'api/BookItems';
let books = []; // books collection array

// get items by calling get on bookitems
function getItems() {
  fetch(uri)
    .then(response => response.json()) // getting json
    .then(data => _displayItems(data)) // pushing json to items
    .catch(error => console.error('Unable to get items.', error));
}

// calling when adding new item on the form
function addItem() {
// making variables for the form elements
  const addNameTextbox = document.getElementById('add-name');
  const addAuthorTextbox = document.getElementById('add-author');
  const addDescTextbox = document.getElementById('add-description');

// pushing elements to book item from textbox text.
  const item = {
    name: addNameTextbox.value.trim(),
	author: addAuthorTextbox.value.trim(),
	description: addDescTextbox.value.trim()
  };
 // doing post with the same uri
  fetch(uri, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
    .then(response => response.json())
    .then(() => {
      getItems(); // if response was good get items
	  
      addNameTextbox.value = ''; // empty the textbox values with submit
	  addAuthorTextbox.value = '';
	  addDescTextbox.value = '';
    }) // if error happened with adding show message
    .catch(error => console.error('Unable to add item.', error));
}

// deleting item with ID 
function deleteItem(id) {
  fetch(`${uri}/${id}`, {
    method: 'DELETE'
  })
  .then(() => getItems())
  .catch(error => console.error('Unable to delete item.', error));
}

// Show edit 
function displayEditForm(id) {
  const item = books.find(item => item.id === id);
  document.getElementById('edit-description').value = item.description;
  document.getElementById('edit-author').value = item.author;  
  document.getElementById('edit-name').value = item.name;
  document.getElementById('edit-id').value = item.id;
  document.getElementById('editForm').style.display = 'block';
}
// update item by id
function updateItem() {
  const itemId = document.getElementById('edit-id').value;
  const item = {
    id: parseInt(itemId, 10),
	name: document.getElementById('edit-name').value.trim(),
    author: document.getElementById('edit-author').value.trim(),
	description: document.getElementById('edit-description').value.trim()
  };
    // using PUT to edit existing item
  fetch(`${uri}/${itemId}`, {
    method: 'PUT',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
  .then(() => getItems())
  .catch(error => console.error('Unable to update item.', error));

  closeInput();

  return false;
}
// close editing
function closeInput() {
  document.getElementById('editForm').style.display = 'none';
}

// show number of books
function _displayCount(itemCount) {
  const name = (itemCount === 1) ? 'book' : 'books';

  document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

// Show listing of bookItems
function _displayItems(data) {
    const tBody = document.getElementById('books');
  tBody.innerHTML = '';
  
  _displayCount(data.length);
    if (data.length > 0) { // if there are books show them in the book-list table

        document.getElementById('book-list').style.display = 'block';
        const button = document.createElement('button');

        data.forEach(item => {

            let editButton = button.cloneNode(false);
            editButton.innerText = 'Edit';
            editButton.className = 'btn btn-default'
            editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

            let deleteButton = button.cloneNode(false);
            deleteButton.innerText = 'Delete';
            deleteButton.className = 'btn btn-danger'
            deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

            let tr = tBody.insertRow();

            let td1 = tr.insertCell(0);
            let textNode1 = document.createTextNode(item.name);
            td1.appendChild(textNode1);

            let td2 = tr.insertCell(1);
            let textNode2 = document.createTextNode(item.author);
            td2.appendChild(textNode2);

            let td3 = tr.insertCell(2);
            let textNode3 = document.createTextNode(item.description);
            td3.appendChild(textNode3);

            let td4 = tr.insertCell(3);
            td4.appendChild(editButton);

            let td5 = tr.insertCell(4);
            td5.appendChild(deleteButton);
        });

        books = data;
    }
    else {
        document.getElementById('book-list').style.display = 'none';
    }
}