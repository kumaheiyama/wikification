import React, { Component } from 'react';
import Parser from 'html-react-parser';
import Marked from 'marked';

export class ContentPages extends Component {
    

    static renderContentPagesTable(contentPages) {
        if (contentPages.length === 0) {
            return <div>No pages</div>;
        }

        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Version</th>
                    </tr>
                </thead>
                    {contentPages.map(contentPage => (
                    <tbody>
                        <tr key={contentPage.id}>
                        <td>{contentPage.title}</td>
                        <td>{contentPage.version}</td>
                        </tr>
                        <tr>
                            <td colSpan="2">
                                {contentPage.contents}
                            </td>
                        </tr>
                        <tr>
                            <td colSpan="2">
                                {Parser(contentPage.parsedContents)}
                            </td>
                        </tr>
                    </tbody>
                    ))}
            </table>
        );
    }

    displayName = ContentPages.name

    constructor(props) {
        super(props);
        this.state = {
            contentPages: [],
            loading: true,
            currentPageContent: '',
            currentPageParsedContent: ''
        };

        Marked.setOptions({
            gfm: true,
            tables: true,
            breaks: false,
            pedantic: false,
            sanitize: true,
            smartLists: true,
            smartypants: false
        });

        fetch('api/ContentPage/GetContentPages?externalId=test1')
            .then(response => response.json())
            .then(data => {
                this.setState({ contentPages: data, loading: false });
            });

    }

    updateParsedContent(evt) {
        this.setState({
            currentPageContent: evt.target.value,
            currentPageParsedContent: Marked(evt.target.value)
        });
    }

    render() {
        const editorTableStyle = {
            width: '100%'
        };
        const editorHalvWidth = {
            width: '50%',
            padding: '10px'
        };

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ContentPages.renderContentPagesTable(this.state.contentPages);

        return (
            <div>
                <h1>Content pages</h1>
                <table style={editorTableStyle}>
                    <tbody>
                        <tr>
                            <td style={editorHalvWidth}>
                                <input type="text" value={this.state.currentPageContent} onChange={evt => this.updateParsedContent(evt)} />
                            </td>
                            <td style={editorHalvWidth}>
                                {Parser(this.state.currentPageParsedContent)}
                            </td>
                        </tr>
                    </tbody>
                </table>
                {contents}
            </div>
        );
    }
}
