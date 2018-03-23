import React from 'react';
import ReactDOM from 'react-dom';
import MessageForm from './components/message_form';

ReactDOM.render(
  <MessageForm/>,
  document.getElementById('app')
);

module.hot.accept();