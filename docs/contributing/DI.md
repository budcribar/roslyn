# FEATURE_NAME

* [x] Proposed
* [ ] Prototype: [Complete](https://github.com/PROTOTYPE_OWNER/roslyn/BRANCH_NAME)
* [ ] Implementation: [In Progress](https://github.com/dotnet/roslyn/BRANCH_NAME)
* [ ] Specification: [Not Started](pr/1)

## Summary
[summary]: #summary

Support using an Interface with the new operator with the ability to bind either statically or dynamically to the implmentation class.

## Motivation
[motivation]: #motivation

Adds Dependency Injection features. For example, when using an ILogger interface in multiple lower level classes the mapping from the interface can be done in one location instead of having to pass the interface into the constructor of multiple classes and the corresponding parent classes.

ILogger logger = single ILogger();
logger.Log("Testing...");


## Detailed design
[design]: #detailed-design

This is the bulk of the proposal. Explain the design in enough detail for somebody familiar with the language to understand, and for somebody familiar with the compiler to implement,  and include examples of how the feature is used. This section can start out light before the prototyping phase but should get into specifics and corner-cases as the feature is iteratively designed and implemented.

## Drawbacks
[drawbacks]: #drawbacks

More difficult to determine the implementation class. IDE could be enhanced to find the implementation easier than when using a DI Container. 
https://ayende.com/blog/4372/rejecting-dependency-injection-inversion

## Alternatives
[alternatives]: #alternatives

What other designs have been considered? What is the impact of not doing this?

## Unresolved questions
[unresolved]: #unresolved-questions

What parts of the design are still undecided?

## Design meetings

Link to design notes that affect this proposal, and describe in one sentence for each what changes they led to.

