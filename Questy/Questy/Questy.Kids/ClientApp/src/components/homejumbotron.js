"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
exports.HomeJumbotron = void 0;
var React = require("react");
var HomeJumbotron = /** @class */ (function (_super) {
    __extends(HomeJumbotron, _super);
    function HomeJumbotron() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    HomeJumbotron.prototype.render = function () {
        return React.createElement("div", { className: "jumbotron text-center" },
            React.createElement("h1", { className: "display-4" },
                "Welcome to Questy.Kids!\u00A0",
                React.createElement("img", { src: require('../img/temp-questy-avatar.png'), height: "80" })),
            React.createElement("p", { className: "lead" }, "An application meant to redesign the way kids think about chores, learning, and growing up."),
            React.createElement("hr", { className: "my-4" }),
            React.createElement("p", null, "By gamifying everyday responsibilities it turns the mundane into fun!"),
            React.createElement("br", null),
            React.createElement("div", { className: "row d-flex justify-content-center align-self-center" },
                React.createElement("button", { className: "button" },
                    "Learn More",
                    React.createElement("div", { className: "button__horizontal" }),
                    React.createElement("div", { className: "button__vertical" }))));
    };
    return HomeJumbotron;
}(React.Component));
exports.HomeJumbotron = HomeJumbotron;
//# sourceMappingURL=homejumbotron.js.map