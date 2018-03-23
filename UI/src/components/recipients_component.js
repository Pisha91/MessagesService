import React from 'react';
class RecipientsComponent extends React.Component {
    constructor(props) {
        super(props);

        this.state = { recipients: [''] };
        this.addRecipient = this.addRecipient.bind(this);
    }

    addRecipient(e) {
        e.preventDefault();
        var array = this.state.recipients;
        array.push('');
        this.props.onUpdate(array);
        this.setState({ recipients: array });
    }

    removeRecipient(index, e) {
        e.preventDefault();
        var array = this.state.recipients.filter((value, recipientIndex) => recipientIndex != index);
        this.props.onUpdate(array);
        this.setState({ recipients: array });
    }

    handleRecipientChange(index, e) {
        var array = this.state.recipients;
        array[index] = e.target.value;
        this.props.onUpdate(array);
        this.setState({ recipients: array });
    }

    // For real app this component better to split into smaller component
    render() {        
        return (
            <div>
                <div>Recipients</div>
                <div><a href="" onClick={this.addRecipient}>Add Recipient</a></div>
                {
                    this.state.recipients.map((object, i) => {
                        if (i == 0) {
                        return <div key={i}><input type="text" value={object} onChange={this.handleRecipientChange.bind(this, i)} required /></div>;
                        }
                        else {
                            return <div key={i}><input type="text"value={object} onChange={this.handleRecipientChange.bind(this, i)} required /><a href="" onClick={this.removeRecipient.bind(this, i)}>Remove Recipient</a></div>;
                        }
                    })
                }
            </div>
        );
    }
}

module.exports = RecipientsComponent;