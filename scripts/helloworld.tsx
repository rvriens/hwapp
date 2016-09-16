/// <reference path="./typings/react/react-global.d.ts" />


declare var mountNode: HTMLElement;

mountNode = document.getElementById("container");

interface HelloWorldProps extends React.Props<any> {
  name: string;
}

class HelloMessage extends React.Component<HelloWorldProps, {}> {
  render() {
    return <div>Hello {this.props.name}</div>;
  }
}

ReactDOM.render(<HelloMessage name="John" />, mountNode);



