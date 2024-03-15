# Friday, March 15 Notes

- Created new CI/CD demo project to demonstrate use of containers
  - Learned about Docker, Kubernetes, OpenShift

## Key Takeaways

- OpenShift is a distribution of Kubernetes
  - 98% of companies using Kubernetes don't run it on premises
    - Run "in the cloud"
- Hash algorithm - given an input, same output always produced
- Container - instance of an image
  - Image - set of layers as you describe
    - If started, then there's a running container of that image
    - Can have many running containers of same image
- Containers rely on namespaces in the Linux kernel
- CI/CD - Continuous Integration / Continuous Delivery (/Deployment)
- Cluster - the ability to have multiple machines that appear as one machine
- Orchestration - running lots of containers, not just on one server, but a bunch of servers
- 2 kinds of nodes in a cluster:

  - "Control Plane" - nodes responsible for "RTB" of the cluster

    - Don't run on any of our software
    - Provide services that are a part of Kubernetes
    - Interface through an API using CL tools (scriptable for pipelines)
      - In normal K9S - called "kubectl"
      - In OpenShift - called "oc"
    - Scheduler
    - Uses a database called etcd

  - "Workers" - where applications run
    - Assigned work

- Number one thing we're responsible for deploying in K9S - a pod
  - A pod runs our container(s) (one or more)
  - Deployed as a unit.
  - Pods are a "virtual localhost"
- K9S are divided into namespaces
  - Can be divided at an application/platform level or even an environment level (e.g., Production vs. Development)
